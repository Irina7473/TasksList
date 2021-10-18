using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace TasksListWpfApp
{
    public class ColorsServices
    {
        public ColorsServices() { }
        public ColorsServices(string name, Brush fond)
        {            
            Name = name;
            Fond = fond;      
        }         
        public string Name { get; set; }
        public Brush Fond { get; set; }       
    }

    public static class ListColors
    {
        private static ObservableCollection<ColorsServices> ColorCollection = new ObservableCollection<ColorsServices>();
        public static ObservableCollection<ColorsServices> GetColors()
        {
            ColorCollection.Add(new ColorsServices("Gray", Brushes.Gray));
            ColorCollection.Add(new ColorsServices("LightBlue", Brushes.LightBlue));
            ColorCollection.Add(new ColorsServices("LightGreen", Brushes.LightGreen));
            ColorCollection.Add(new ColorsServices("Lime", Brushes.Lime));
            ColorCollection.Add(new ColorsServices("Yellow", Brushes.Yellow));
            ColorCollection.Add(new ColorsServices("Orange", Brushes.Orange));
            ColorCollection.Add(new ColorsServices("Coral", Brushes.Coral));
            ColorCollection.Add(new ColorsServices("Tomato", Brushes.Tomato));
            ColorCollection.Add(new ColorsServices("PaleVioletRed", Brushes.PaleVioletRed));
            ColorCollection.Add(new ColorsServices("SandyBrown", Brushes.SandyBrown));

            return ColorCollection;
        }
    }    
}