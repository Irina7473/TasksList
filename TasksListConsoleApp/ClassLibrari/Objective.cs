using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrari
{
    //public delegate void Message(string message);
    
    public class Objective
    {
        public static Message Info;
        public static event Update Creat = () => { /*Info?.Invoke("Задача создана");*/ };

        public int Importance { get; set; }
        public string TaskContent { get; set; }
        public string Limit { get; set; }

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
