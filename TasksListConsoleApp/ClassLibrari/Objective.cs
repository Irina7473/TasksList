using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrari
{
    public class Objective
    {
        public int Importance { get; set; }
        public string TaskContent { get; set; }
        public string Limit { get; set; }

        public Objective() { }
        public Objective(int importance, string taskContent, string limit)
        {
            Importance = importance;
            TaskContent = taskContent;
            Limit = limit;
        }      
    }        
}
