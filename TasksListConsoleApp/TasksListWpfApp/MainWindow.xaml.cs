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
        public ObservableCollection<Objective> taskList;
        Dictionary<int, ImportanceTable> level = new (3);
        int importance;
        string taskContent="";
        string limit="";

        public MainWindow()
        {
            InitializeComponent();

            TableImportance1.IsEnabled = false;
            TableImportance2.IsEnabled = false;
            TableImportance3.IsEnabled = false;
            TextBox_TaskContent.IsEnabled = false;
            TextBox_Limit.IsEnabled = false;
            SaveTask.IsEnabled = false;
            
            taskList = new ObservableCollection<Objective> ();
            ObjectiveList.ItemsSource = taskList;
        }

        private void SelectAction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = ((TextBlock)SelectAction.SelectedItem).Name;
            
            if (select == "SelectZ")
            {
                level.Clear();
                level = CreatTaskList();
            }

            if (select == "SelectX")
            {
                TextBox_TaskContent.IsEnabled = true;
                TextBox_Limit.IsEnabled = true;
                SaveTask.IsEnabled = true;
            }

            if (select == "SelectC")   { }

            if (select == "SelectV")
            {
                TableImportance1.IsEnabled = true;
                TableImportance2.IsEnabled = true;
                TableImportance3.IsEnabled = true;
            }

            if (select == "SelectB") { }           
        }
        
        
        private void Importance1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Importance1_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Importance2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Importance2_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Importance3_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Importance3_Unchecked(object sender, RoutedEventArgs e)
        {

        }

     
        private void SelectColor1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SelectColor2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SelectColor3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
            var task = new Objective(importance, taskContent, limit);
            level[task.Importance].AnyLevel.Enqueue(task);
            taskList = new ObservableCollection<Objective> ();
            ObjectiveList.ItemsSource = taskList;
            
            foreach (var k in level.Keys)
            {
                if (level[k].AnyLevel.Count != 0)
                {
                    var taskArr = level[k].AnyLevel.ToArray();
                    foreach (var t in taskArr) taskList.Add(new Objective(k, t.TaskContent, t.Limit));
                }
            }          
            
            MessageBox.Show("Добавляем задачу");
        }

        private void Objective_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void СlearForm_Click(object sender, RoutedEventArgs e)
        {
            TextBox_TaskContent.Text = "";
            TextBox_Limit.Text = "";
            RadioButton_Importance1.IsChecked = false;
            RadioButton_Importance2.IsChecked = false;
            RadioButton_Importance3.IsChecked = false;
        }

        public static Dictionary<int, ImportanceTable> CreatTaskList()
        {
            var level = new Dictionary<int, ImportanceTable>(3);
            level.Add(3, new ImportanceTable(new Queue<Objective>(), 3, ConsoleColor.Yellow));
            level.Add(2, new ImportanceTable(new Queue<Objective>(), 2, ConsoleColor.Blue));
            level.Add(1, new ImportanceTable(new Queue<Objective>(), 1, ConsoleColor.Magenta));
            return level;
        }        
    }
}
