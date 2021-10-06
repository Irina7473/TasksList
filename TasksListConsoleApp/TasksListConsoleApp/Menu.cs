using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClassLibrari;
using System.Drawing;

namespace TasksListConsoleApp
{
    public static class Menu
    {
        static int numberLevel = 3;
        static Dictionary<int, ImportanceTable> level;// = new Dictionary<int, ImportanceTable>(numberLevel);

        public static void Welcome()
        {
            Console.WriteLine("******** Список задач! ********");
            Console.WriteLine(" Программа для составления списка задач в порядке их важности\n");
        }
        public static void Selection()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Сделайте выбор");
            Console.WriteLine("-z. Создать новый список задач");
            Console.WriteLine("-x. Добавить новые задачи в список");
            Console.WriteLine("-c. Вывести список задач на экран");
            Console.WriteLine("-v. Создать таблицу важности");
            Console.WriteLine("-b. Выход из программы");
            Console.WriteLine("-----------------------------------------");
        }

        public static void EventMenu(string select)
        {
            if (select.Contains("-z"))
            {
                Console.WriteLine("Создание нового списка задач");
                CreatTaskList();
                Selection();
            }

            if (select.Contains("-x"))
            {
                Console.WriteLine("Добавление новых задач в список");
                CreatObjective();
                Selection();
            }

            if (select.Contains("-c"))
            {
                Console.WriteLine("Вывод списка задач на экран");
                SaveToFile.ConsolReader();
                Selection();
            }

            if (select.Contains("-v"))
            {
                Console.WriteLine("Создание своей таблицы важности");
                Selection();
            }

            if (select.Contains("-b"))
            {
                Console.WriteLine("Выполнен выход");
            }
        }

        public static void CreatTaskList()
        {
            level = new Dictionary<int, ImportanceTable>(numberLevel);
            level.Add (3, new ImportanceTable(new Queue<Objective>(), 3, Color.Yellow));
            level.Add (2, new ImportanceTable(new Queue<Objective>(), 2, Color.Blue));
            level.Add (1, new ImportanceTable(new Queue<Objective>(), 1, Color.Magenta));
            var path=SaveToFile.FilePath;
            if (File.Exists(path))
            {
                StreamReader reader = new(path);
                while (!reader.EndOfStream)
                {
                    var task = new Objective();
                    string text = reader.ReadLine();
                    //string[] elements = text.Split('-');
                    var elements = text.Split('-');                    
                    for(var i=0; i<elements.Length; i++)
                    {
                        Console.WriteLine(elements[i]);

                        int res;
                        if (i == 0)
                        {
                            Int32.TryParse(elements[i], out res);
                            task.Importance = res+1;
                         }
                        if (i == 1) task.TaskContent = elements[i]; 
                        if (i == 2) task.Limit = elements[i];
                    }
                    /*
                    var elements = text.Split('-');
                    task.TaskContent = elements[1];
                    task.Limit = elements[2];
                    task.Importance = int.Parse(elements[0])+1;*/
                    level[task.Importance].AnyLevel.Enqueue(task);
                }
                reader.Close();
            } 
        }

        public static void CreatObjective()
        {
            if (level.Count == 0) CreatTaskList();
            var task = AddObjective();
            level[task.Importance].AnyLevel.Enqueue(task);
            Console.WriteLine("  Добавить еще 1 задачу?\n  1 - да  \n  2 - нет");
            var select = Console.ReadLine();
            if (select.Contains("1"))
            {
                CreatObjective();
            }

            if (select.Contains("2"))
            {
                SaveToFile.RecordToFile(level);
                return;
            }
        }

        public static Objective AddObjective()
        {
            var task = new Objective();
            Console.WriteLine("Введите задачу");
            task.TaskContent = Console.ReadLine();
            Console.WriteLine("Введите срок выполнения задачи");
            task.Limit = Console.ReadLine();
            Console.WriteLine("Введите важность задачи по шкале от 1 до 3 (3- очень важная)");
            task.Importance = int.Parse(Console.ReadLine());

            return task;
        }
    }
}