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
        //Не годится public ObservableCollection<Objective>, т.к. не дает возможность раскрасить строки каждую в свой цвет
        List<ListViewItem> ITEMS = new List<ListViewItem>();
        Dictionary<int, ImportanceTable> level;

        int importance = 0;
        string taskContent = "";
        string limit = "";
        Objective changeTask = new Objective();

        Brush color1 = Brushes.Gray;
        Brush color2 = Brushes.Lime;
        Brush color3 = Brushes.Tomato;
        
        //Вариант с моей коллекцией типа ColorsServices для задания фона по уровню важности задачи
        private ObservableCollection<ColorsServices> ColorCollection = new ObservableCollection<ColorsServices>();
        public void GetColorId()
        {
            ColorCollection.Add(new ColorsServices( "Gray", Brushes.Gray));
            ColorCollection.Add(new ColorsServices("LightBlue", Brushes.LightBlue));
            ColorCollection.Add(new ColorsServices("LightGreen", Brushes.LightGreen));
            ColorCollection.Add(new ColorsServices("Lime", Brushes.Lime));
            ColorCollection.Add(new ColorsServices("Yellow", Brushes.Yellow));
            ColorCollection.Add(new ColorsServices("Orange", Brushes.Orange));
            ColorCollection.Add(new ColorsServices("Coral", Brushes.Coral));
            ColorCollection.Add(new ColorsServices("Tomato", Brushes.Tomato));
            ColorCollection.Add(new ColorsServices("PaleVioletRed", Brushes.PaleVioletRed));
            ColorCollection.Add(new ColorsServices("SandyBrown", Brushes.SandyBrown));
        }

        /*Вариант с коллекцией типа Dictionary для задания фона по уровню важности задачи
        readonly Dictionary<string, Brush> colorSet = new Dictionary<string, Brush>
        {
            {"Gray",Brushes.Gray },
            {"LightBlue",Brushes.LightBlue },
            {"LightGreen",Brushes.LightGreen },
            {"Lime",Brushes.Lime },
            {"Yellow",Brushes.Yellow },
            {"Orange",Brushes.Orange },
            {"Coral",Brushes.Coral },
            {"Tomato",Brushes.Tomato },
            {"PaleVioletRed",Brushes.PaleVioletRed },
            {"SandyBrown",Brushes.SandyBrown }
        };
        */

        public MainWindow()
        {
            InitializeComponent();

            TableImportance1.IsEnabled = false;
            TableImportance2.IsEnabled = false;
            TableImportance3.IsEnabled = false;
            SaveColor.IsEnabled = false;
            SaveTask.IsEnabled = false;
            ChangeTask.IsEnabled = false;
            СlearForm.IsEnabled = false;
            ChangeColor.IsEnabled = false;
            RadioButton_Importance1.Background = color1;
            RadioButton_Importance2.Background = color2;
            RadioButton_Importance3.Background = color3;
                        
            ObjectiveList.ItemsSource = ITEMS;
            GetColorId();
            SelectColor1.ItemsSource = ColorCollection;
            SelectColor2.ItemsSource = ColorCollection;
            SelectColor3.ItemsSource = ColorCollection;
        }

        private void Creating_Click(object sender, RoutedEventArgs e)
        {
            ImportanceTable.Info = msg => MessageBox.Show(msg);
            ITEMS.Clear();
            ObjectiveList.Items.Refresh();
            level = ImportanceTable.CreatTaskList();
        }

        private void Addendum_Click(object sender, RoutedEventArgs e)
        {
            if (level == null)
            {
                ImportanceTable.Info = msg => MessageBox.Show(msg);
                level = ImportanceTable.CreatTaskList();
            }
            SaveTask.IsEnabled = true;
            СlearForm.IsEnabled = true;
        }

        private void Uploading_Click(object sender, RoutedEventArgs e)
        {
            //ImportanceTable.Info = msg => MessageBox.Show(msg);
            ITEMS.Clear();
            ObjectiveList.Items.Refresh();
            level = SaveToFile.ReaderFromFail();
            UpdateObjectiveList();
        }

        private void Discharge_Click(object sender, RoutedEventArgs e)
        {
            SaveToFile.Info = msg => MessageBox.Show(msg);
            SaveToFile.RecordToFile(level);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            ExitWindow exit = new ExitWindow();
            if (exit.ShowDialog() == true) this.Close();
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
                level[task.Importance].AddTask(task);
                UpdateObjectiveList();
                //ImportanceTable.Add += UpdateObjectiveList;
                //ImportanceTable.Info = msg => MessageBox.Show(msg);
            }
        }

        private void ChangeTask_Click(object sender, RoutedEventArgs e)
        {
            foreach(var uptask in level[changeTask.Importance].AnyLevel)
            {
                if (uptask==changeTask)
                {
                    uptask.Importance = importance;
                    uptask.TaskContent = taskContent;
                    uptask.Limit = limit;
                    level[uptask.Importance].AddTask(uptask);
                    level[changeTask.Importance].RemoveTask(uptask);
                    UpdateObjectiveList();
                    return;
                }
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
        
        private void MenuItem_Click_Change(object sender, RoutedEventArgs e)
        {
            changeTask = (ObjectiveList.SelectedItem as ListViewItem).Content as Objective;

            importance = changeTask.Importance;
            if (importance == 1) RadioButton_Importance1.IsChecked = true;
            if (importance == 2) RadioButton_Importance2.IsChecked = true;
            if (importance == 3) RadioButton_Importance3.IsChecked = true;
            TextBox_TaskContent.Text = changeTask.TaskContent;
            TextBox_Limit.Text = changeTask.Limit;

            ChangeTask.IsEnabled = true;
            СlearForm.IsEnabled = true;            
        }

        private void MenuItem_Click_Delete(object sender, RoutedEventArgs e)
        {
            var task = (ObjectiveList.SelectedItem as ListViewItem).Content as Objective;
            level[task.Importance].RemoveTask(task);            
            UpdateObjectiveList();
        }

        private void UpdateObjectiveList()
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
            }
            MessageBox.Show("Список обновлен");
        }

        private void Create_importance_tables_Click(object sender, RoutedEventArgs e)
        {
            TableImportance1.IsEnabled = true;
            TableImportance2.IsEnabled = true;
            TableImportance3.IsEnabled = true;
            SaveColor.IsEnabled = true;
        }

        private void SaveColor_Click(object sender, RoutedEventArgs e)
        {
            //Вариант с моей коллекцией типа ColorsServices
            if (TableImportance1.IsChecked == true) color1 = (SelectColor1.SelectedItem as ColorsServices).Fond;
            if (TableImportance2.IsChecked == true) color2 = (SelectColor2.SelectedItem as ColorsServices).Fond;
            if (TableImportance3.IsChecked == true) color3 = (SelectColor3.SelectedItem as ColorsServices).Fond;
            //Вариант с коллекцией типа Dictionary
            //if (TableImportance3.IsChecked == true) color3 = colorSet[SelectColor3.SelectedValue.ToString().Substring(1, SelectColor3.SelectedValue.ToString().IndexOf(",") - 1)];

            RadioButton_Importance1.Background = color1;
            RadioButton_Importance2.Background = color2;
            RadioButton_Importance3.Background = color3;

            ChangeColor.IsEnabled = true;
            SelectColor1.SelectedItem=null;
            SelectColor2.SelectedItem = null;
            SelectColor3.SelectedItem = null;
            TableImportance1.IsChecked = false;
            TableImportance2.IsChecked = false;
            TableImportance3.IsChecked = false;
            TableImportance1.IsEnabled = false;
            TableImportance2.IsEnabled = false;
            TableImportance3.IsEnabled = false;
            
            SaveColor.IsEnabled = false;
        }
        private void ChangeColor_Click(object sender, RoutedEventArgs e)
        {
            UpdateObjectiveList();
            ChangeColor.IsEnabled = false;
        }

    }
}