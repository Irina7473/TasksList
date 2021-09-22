using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassLibrari;

namespace TasksListWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>    
    public partial class MainWindow : Window
    {
        //public ObservableCollection<Objective> taskList;
        List<ListViewItem> ITEMS = new List<ListViewItem>();
        Dictionary<int, ImportanceTable> level;

        int importance=0;
        string taskContent="";
        string limit="";
        Brush color1= Brushes.Silver;
        Brush color2= Brushes.Lime;
        Brush color3= Brushes.Tomato;

        public MainWindow()
        {
            InitializeComponent();

            TableImportance1.IsEnabled = false;
            TableImportance2.IsEnabled = false;
            TableImportance3.IsEnabled = false;
            SelectColor.IsEnabled = false;
            SaveColor.IsEnabled = false;            
            SaveTask.IsEnabled = false;
            RadioButton_Importance1.Background = color1;
            RadioButton_Importance2.Background = color2;
            RadioButton_Importance3.Background = color3;

            //taskList = new ObservableCollection<Objective> ();
            //ObjectiveList.ItemsSource = taskList;
            ObjectiveList.ItemsSource = ITEMS;
        }

        private void SelectAction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = ((TextBlock)SelectAction.SelectedItem).Name;

            if (select == "SelectZ")
            {
                ITEMS.Clear();
                ObjectiveList.Items.Refresh();
                level = ImportanceTable.CreatTaskList();
                ImportanceTable.Info = msg => MessageBox.Show(msg);
            }

            if (select == "SelectX")
            {
                if (level == null)
                {
                    level = ImportanceTable.CreatTaskList();
                    ImportanceTable.Info = msg => MessageBox.Show(msg);
                }
                SaveTask.IsEnabled = true;                
            }

            if (select == "SelectC")
            {
                SaveToFile.RecordToFile(level);
                SaveToFile.Info = msg => MessageBox.Show(msg);                
            }

                if (select == "SelectV")
            {
                TableImportance1.IsEnabled = true;
                TableImportance2.IsEnabled = true;
                TableImportance3.IsEnabled = true;
                SelectColor.IsEnabled = true;
                SaveColor.IsEnabled = true;
            }

            if (select == "SelectB") this.Close();           
        }             
     
        private void SelectColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Не работает этот код
            SelectColor.Background = ((Button)SelectAction.SelectedItem).Background;            
        }

        private void Color_Click(object sender, RoutedEventArgs e)
        {
            var color = (Button)sender;
            if (TableImportance1.IsChecked == true) TableImportance1.Background = color.Background;
            if (TableImportance2.IsChecked == true) TableImportance2.Background = color.Background;
            if (TableImportance3.IsChecked == true) TableImportance3.Background = color.Background;
        }
        private void SaveColor_Click(object sender, RoutedEventArgs e)
        {
            color1 = RadioButton_Importance1.Background = TableImportance1.Background;
            color2 = RadioButton_Importance2.Background = TableImportance2.Background;
            color3 = RadioButton_Importance3.Background = TableImportance3.Background;

            TableImportance1.IsChecked = false;
            TableImportance2.IsChecked = false;
            TableImportance3.IsChecked = false;
            TableImportance1.IsEnabled = false;
            TableImportance2.IsEnabled = false;
            TableImportance3.IsEnabled = false;
            SelectColor.IsEnabled = false;
            SaveColor.IsEnabled = false;
        }

        private void Importance_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            pressed.IsChecked = true;
            if (pressed.Content.ToString() == "Не очень важно") importance = 1;
            if (pressed.Content.ToString() == "Важно") importance = 2;
            if (pressed.Content.ToString() == "Очень важно") importance = 3;
        }
        private void TaskContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            taskContent = TextBox_TaskContent.Text.ToString();
        }

        private void Limit_TextChanged(object sender, TextChangedEventArgs e)
        {
            limit = TextBox_Limit.Text.ToString();
        }

        private void SaveTask_Click(object sender, RoutedEventArgs e)
        {
            if (importance == 0) MessageBox.Show("Выберите уровень важности задачи");
            else
            {
                var task = new Objective(importance, taskContent, limit);
                Objective.Info = msg => MessageBox.Show(msg);
                
                level[task.Importance].AddTask(task);
                ImportanceTable.Add += UpdateObjectiveList;
                ImportanceTable.Info = msg => MessageBox.Show(msg);
               
                //level[task.Importance].AnyLevel.Enqueue(task);
                //UpdateObjectiveList();
               
                /*
                ITEMS = new List<ListViewItem>();

                foreach (var k in level.Keys)
                {
                    if (level[k].AnyLevel.Count != 0)
                    {
                        var taskArr = level[k].AnyLevel.ToArray();
                        foreach (var t in taskArr)
                        {
                            ListViewItem OneItem = new ListViewItem();
                            if (k == 1) OneItem.Background = color1;
                            if (k == 2) OneItem.Background = color2;
                            if (k == 3) OneItem.Background = color3;

                            OneItem.Content = new Objective(k, t.TaskContent, t.Limit);
                            ITEMS.Add(OneItem);
                            ObjectiveList.ItemsSource = ITEMS;

                            //taskList.Add(new Objective(k, t.TaskContent, t.Limit)); 
                        }
                    }
                    ObjectiveList.Items.Refresh();
                }*/

                //MessageBox.Show("Задача добавлена в список");
            }
        }
   
        private void СlearForm_Click(object sender, RoutedEventArgs e)
        {
            TextBox_TaskContent.Text = "";
            TextBox_Limit.Text = "";
            RadioButton_Importance1.IsChecked = false;
            RadioButton_Importance2.IsChecked = false;
            RadioButton_Importance3.IsChecked = false;
        }

        private void UpdateObjectiveList ()
        {
            ITEMS = new List<ListViewItem>();

            foreach (var k in level.Keys)
            {
                if (level[k].AnyLevel.Count != 0)
                {
                    var taskArr = level[k].AnyLevel.ToArray();
                    foreach (var t in taskArr)
                    {
                        ListViewItem OneItem = new ListViewItem();
                        if (k == 1) OneItem.Background = color1;
                        if (k == 2) OneItem.Background = color2;
                        if (k == 3) OneItem.Background = color3;

                        OneItem.Content = new Objective(k, t.TaskContent, t.Limit);
                        ITEMS.Add(OneItem);
                        ObjectiveList.ItemsSource = ITEMS; 
                    }
                }
                ObjectiveList.Items.Refresh();
                MessageBox.Show("Список обновлен");
            }

        }
    }
}