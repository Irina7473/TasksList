using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksListConsoleApp
{
    public static class Menu
    {
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
                SaveToFile.ClearFile();
                Selection();
            }

            if (select.Contains("-x"))
            {
                Console.WriteLine("Добавление новой задачи в список");
                CreatObjective();
                Selection();
            }

            if (select.Contains("-c"))
            {
                Console.WriteLine("Вывод списка задач на экран");
                SaveToFile.Reader();
                Selection();
            }

            if (select.Contains("-v"))
            {
                Console.WriteLine("Создание таблицы важности");
                Selection();
            }

            if (select.Contains("-b"))
            {
                Console.WriteLine("Выполнен выход");
            }
        }

        public static void CreatObjective()
        {
            SaveToFile.RecordToFile(AddObjective());
            Console.WriteLine("  Добавить еще 1 задачу?\n  1 - да  \n  2 - нет");
            var select = Console.ReadLine();
            if (select.Contains("1"))
            {
                CreatObjective();
            }

            if (select.Contains("2"))
            {
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
            Console.WriteLine("Введите важность задачи по шкале от 0 до 4 (4- очень важная)");
            task.Importance = int.Parse(Console.ReadLine());
            return task;
        }
    }
}