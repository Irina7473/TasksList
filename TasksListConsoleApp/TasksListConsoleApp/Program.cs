using System;

namespace TasksListConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.Welcome();
            Menu.Selection();
            string select="";
            do
            {
                select = Console.ReadLine();
                Menu.EventMenu(select);
            } while (!select.Contains("-b"));
            

            /*
            var task = new Objective();
            Console.WriteLine("Введите задачу");
            task.TaskContent=Console.ReadLine();
            Console.WriteLine("Введите срок выполнения задачи");
            task.Limit = Console.ReadLine();
            Console.WriteLine("Введите важность задачи по шкале от 0 до 4 (4- очень важная)");
            task.Importance =int.Parse(Console.ReadLine());
            */
            

        }
    }
}

/*
Написать программу по сохранению задач в файл и вывода их на экран в порядке важности задачи.
При вводе задачи, ей устанавливается важность. 
При сохранении в файл задачи сохраняются в порядке важности.
При выводе - задачи помечаются цветами в зависимости от таблицы важности. 
Таблицу важности пользователь создаёт сам. Т.е. сам определяет какой цвет подходит какой важности.
*/