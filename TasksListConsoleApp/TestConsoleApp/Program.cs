using System;
using System.Collections.Generic;
using System.Drawing;

using ClassLibrari;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Тест листа");
            /*
            var L = new List<int> { 1,2,3,4,5};
            ShouListInt(L);
            L.Add(6);
            ShouListInt(L);
            L.Insert(1,0);
            ShouListInt(L);
            L.Remove(4);
            ShouListInt(L);
            L.RemoveAt(1);
            ShouListInt(L);
            Console.WriteLine("-----------------------------------");

            void ShouListInt(List<int> list)
            {
                foreach(var l in list) Console.Write($"{l}, ");
                Console.WriteLine();
            }*/

            var tasks = new List<Objective> { new Objective(5, "задача 1", "срок 1") };
            //ShouListTasks(tasks);
            tasks.Add(new Objective(2, "задача 2", "срок 2"));
            var task3 = new Objective(4, "задача 3", "срок 3");
            tasks.Add(task3);
            tasks.Add(new Objective(2, "задача 4", "срок 4"));
            ShouListTasks(tasks);
            //tasks.Remove(task3);
            //ShouListTasks(tasks);
            Console.WriteLine("-----------------------------------");

            void ShouListTasks(List<Objective> list)
            {
                foreach (var l in list) Console.WriteLine($"{l.Importance}, {l.TaskContent}, {l.Limit}");
                Console.WriteLine();
            }

            var ITable = new ImportanceTable(tasks, 2, Color.Blue);
            ShouListITable(ITable);
            var task5 = new Objective(4, "задача 5", "срок 5");
            tasks.Add(task5);
            ShouListITable(ITable);
            tasks.Remove(task3);
            ShouListITable(ITable);

            Console.WriteLine("-----------------------------------");

            void ShouListITable(ImportanceTable list)
            {
                Console.WriteLine($"{list.NumberLevel}, {list.Color}  ");
                foreach (var l in list.AnyLevel) Console.WriteLine($"{l.Importance}, {l.TaskContent}, {l.Limit}");
                Console.WriteLine();
            }


        }
    }
}
