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
        public ColorsServices(string name, System.Windows.Media.Brush fond)
        {            
            Name = name;
            Fond = fond;      
        }         
        public string Name { get; set; }
        public System.Windows.Media.Brush Fond { get; set; }       
    }
}