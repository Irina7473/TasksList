using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ClassLibrari;

namespace TasksListConsoleApp
{
    public static class SaveToFile
    {        
        public static string FilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TaskList.txt");
        /*
        public static SaveToFile() { }
        public static SaveToFile(string path)
        {                        
            try
            {
                FilePath = path;                
            }
            catch
            {
                throw new Exception("Путь к месту записи файла не найден");
            }
        }*/

        public static void RecordToFile(Dictionary<int, ImportanceTable> level)
        {
            string text="";
            using var file=File.CreateText(FilePath);
            foreach (var k in level.Keys)
            {
                if (level[k].AnyLevel.Count!=0)
                {
                    var taskArr = level[k].AnyLevel.ToArray();
                    foreach (var task in taskArr)
                    {
                        text = task.Importance + "/" + task.TaskContent + "/" + task.Limit;
                        file.WriteLine(text);
                    }
                }
            }                        
        }
        
        public static void ConsolReader()
        {
            if (File.Exists(FilePath))
            {
                StreamReader reader = new(FilePath);
                Console.WriteLine(reader.ReadToEnd());
                reader.Close();
            }
            else Console.WriteLine("Файл не существует или путь указан неверно");
        }
        /*
        public static void Reader()
        {
            if (File.Exists(FilePath))
            {
                StreamReader reader = new(FilePath);
                Menu.CreatTaskList();                
                reader.Close();
            }
            else Console.WriteLine("Файл не существует или путь указан неверно");
        }       */

        public static void ClearFile()
        {
            if (File.Exists(FilePath))
                File.WriteAllText(FilePath, null);
            else Console.WriteLine("Файл не существует или путь указан неверно");
        }
    }
}