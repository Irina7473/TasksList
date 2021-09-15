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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TasksListWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectAction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = ((TextBlock)SelectAction.SelectedItem).Name;
            /*
            if (select == "SelectZ") ;
            if (select == "SelectX") ;
            if (select == "SelectC") ;
            if (select == "SelectV") ;
            if (select == "SelectB") ;
            */
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

    }
}
