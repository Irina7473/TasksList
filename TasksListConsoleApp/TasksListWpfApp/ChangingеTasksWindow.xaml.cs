using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace TasksListWpfApp
{
    /// <summary>
    /// Логика взаимодействия для ChangingеTasksWindow.xaml
    /// </summary>
    public partial class ChangingеTasksWindow : Window
    {
        public ChangingеTasksWindow()
        {
            InitializeComponent();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            MessageBox.Show("Delete");
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
