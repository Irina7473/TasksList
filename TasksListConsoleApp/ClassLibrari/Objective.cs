using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrari
{
    //public delegate void Message(string message);
    
    public class Objective: INotifyPropertyChanged
    {
        public static Message Info;
        public static event Update Creat = () => { /*Info?.Invoke("Задача создана");*/ };
        /*
        public int Importance { get; set; }
        public string TaskContent { get; set; }
        public string Limit { get; set; }
        */

        private int _importance;
        private string _taskContent;
        private string _limit;

        public int Importance
        {
            get { return _importance; }
            set { _importance = value; OnPropertyChanged("Importance"); }
        }
        public string TaskContent
        {
            get { return _taskContent; }
            set { _taskContent = value; OnPropertyChanged("TaskContent"); }
        }
        public string Limit 
        { 
            get { return _limit; }
            set { _limit = value; OnPropertyChanged("Limit"); } 
        }
        
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        
        public Objective() { }
        public Objective(int importance, string taskContent, string limit)
        {
            Importance = importance;
            TaskContent = taskContent;
            Limit = limit;
            Creat();
        }
                
        public static bool operator ==(Objective left, Objective rigt)
        {
            if (left.Importance == rigt.Importance && left.TaskContent == rigt.TaskContent && left.Limit == rigt.Limit) return true;
            else return false;
        }

        public static bool operator !=(Objective left, Objective rigt)
        {
            if (left == rigt) return false;
            else return true;
        }
    }        
}
