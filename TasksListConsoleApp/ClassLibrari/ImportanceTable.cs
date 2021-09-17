using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibrari
{
    public class ImportanceTable
    {
        public Queue<Objective> AnyLevel { get; set; }
        public int NumberLevel { get; set; }
        public ConsoleColor Color { get; set; }

        public ImportanceTable(Queue<Objective> anyLevel, int numberLevel, ConsoleColor color)
        {
            AnyLevel = anyLevel;
            NumberLevel = numberLevel;
            Color = color;
        }        
    }
}
