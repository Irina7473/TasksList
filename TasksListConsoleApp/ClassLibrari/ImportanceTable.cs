using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibrari
{
    public delegate void Message(string message);
    public delegate void Update();
    public class ImportanceTable
    {
        public static Message Info;
        public static event Update Add = () => { Info?.Invoke("Задача добавлена в список"); };

        public Queue<Objective> AnyLevel { get; set; }
        public int NumberLevel { get; set; }
        public ConsoleColor Color { get; set; }

        public ImportanceTable(Queue<Objective> anyLevel, int numberLevel, ConsoleColor color)
        {
            AnyLevel = anyLevel;
            NumberLevel = numberLevel;
            Color = color;
        }

        public static Dictionary<int, ImportanceTable> CreatTaskList()
        {
            var level = new Dictionary<int, ImportanceTable>(3);
            level.Add(3, new ImportanceTable(new Queue<Objective>(), 3, ConsoleColor.White));
            level.Add(2, new ImportanceTable(new Queue<Objective>(), 2, ConsoleColor.White));
            level.Add(1, new ImportanceTable(new Queue<Objective>(), 1, ConsoleColor.White));

            Info?.Invoke("Новый список задач создан");
            return level;
        }

        public void AddTask (Objective task)
        {            
            AnyLevel.Enqueue(task);
            Add();          
        }
                
    }
}
