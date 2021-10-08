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
using System.Drawing;

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

        int importance = 0;
        string taskContent = "";
        string limit = "";

        private ObservableCollection<ColorsServices> ColorCollection = new ObservableCollection<ColorsServices>();
        public void GetColorId()
        {
            ColorCollection.Add(new ColorsServices(0, System.Drawing.Color.Bisque));
            ColorCollection.Add(new ColorsServices(1, System.Drawing.Color.Yellow));
            //ColorCollection.Add(new ColorsServices(2, Brushes.Green));
            //ColorCollection.Add(new ColorsServices(3, Brushes.Gray));
            // ColorCollection.Add(new ColorsServices(4, Brushes.PaleGreen));
            // ColorCollection.Add(new ColorsServices(5, Brushes.Violet));
            // ColorCollection.Add(new ColorsServices(6, Brushes.CadetBlue));
        }

        System.Windows.Media.Brush color1 = System.Windows.Media.Brushes.Silver;
        System.Windows.Media.Brush color2 = System.Windows.Media.Brushes.Lime;
        System.Windows.Media.Brush color3 = System.Windows.Media.Brushes.Tomato;

        SolidColorBrush redBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("Red");

        public MainWindow()
        {
            InitializeComponent();

            TableImportance1.IsEnabled = false;
            TableImportance2.IsEnabled = false;
            TableImportance3.IsEnabled = false;
            SaveColor.IsEnabled = false;
            SaveTask.IsEnabled = false;
            RadioButton_Importance1.Background = color1;
            RadioButton_Importance2.Background = color2;
            RadioButton_Importance3.Background = color3;

            //taskList = new ObservableCollection<Objective> ();
            //ObjectiveList.ItemsSource = taskList;
            ObjectiveList.ItemsSource = ITEMS;
            GetColorId();
            SelectColor1.ItemsSource = ColorCollection;
        }

        private void Uploading_Click(object sender, RoutedEventArgs e)
        {
            //ImportanceTable.Info = msg => MessageBox.Show(msg);
            ITEMS.Clear();
            ObjectiveList.Items.Refresh();
            level = SaveToFile.ReaderFromFail();
            UpdateObjectiveList();
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
        }

        private void Discharge_Click(object sender, RoutedEventArgs e)
        {
            SaveToFile.Info = msg => MessageBox.Show(msg);
            SaveToFile.RecordToFile(level);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            ExitWindow exit = new ExitWindow();
            if (exit.ShowDialog() == true)
            {
                this.Close();
            }

        }

        private void Create_importance_tables_Click(object sender, RoutedEventArgs e)
        {
            TableImportance1.IsEnabled = true;
            TableImportance2.IsEnabled = true;
            TableImportance3.IsEnabled = true;
            SaveColor.IsEnabled = true;
        }

        private void SelectColor_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void SelectColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Не работает этот код
            //SelectColor.Background = ((TextBlock)SelectAction.SelectedItem).Background;
            /*
            System.Windows.Media.Brush color="Blue";
            if (TableImportance1.IsChecked == true) TableImportance1.Background = color;
            if (TableImportance2.IsChecked == true) TableImportance2.Background = color;
            if (TableImportance3.IsChecked == true) TableImportance3.Background = color;
            */
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

                level[task.Importance].AddTask(task);
                UpdateObjectiveList();
                //ImportanceTable.Add += UpdateObjectiveList;
                //ImportanceTable.Info = msg => MessageBox.Show(msg);
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

    }
}