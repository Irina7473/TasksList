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
            Console.WriteLine("Программа для составления списка задач в порядке их важности");
        }
        public static void Selection()
        {
            Console.WriteLine("-z. Создать новый список задач");
            Console.WriteLine("-x. Добавить новые задачи в список");
            Console.WriteLine("-c. Вывести список задач на экран");
            Console.WriteLine("-v. Создать таблицу важности");
            Console.WriteLine("-b. Выход из программы");
        }

        public static void EventMenu(string select)
        {
            if (select.Contains("-z"))
            {
                Console.WriteLine("Создать новый список задач");
            }

            if (select.Contains("-x"))
            {
                Console.WriteLine("Добавить новые задачи в список");
            }

            if (select.Contains("-c"))
            {
                Console.WriteLine("Вывод списка задач на экран");
                SaveToFile.Reader();
            }

            if (select.Contains("-v"))
            {
                Console.WriteLine("Создать таблицу важности");
            }

            if (select.Contains("-b"))
            {
                Console.WriteLine("Выполнен выход");
            }
        }
    }
}