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