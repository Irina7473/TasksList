using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ClassLibrari;

namespace TasksListWpfApp
{    
    public static class SaveToFile
    {
        public static Message Info;
        public static string FilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TaskList.txt");
        
        public static void RecordToFile(Dictionary<int, ImportanceTable> level)
        {
            if (level ==null) Info?.Invoke("Список не существует. Создайте список задач.");
            else
            {
                string text = "";
                using var file = File.CreateText(FilePath);
                foreach (var k in level.Keys)
                {
                    if (level[k].AnyLevel.Count != 0)
                    {
                        var taskArr = level[k].AnyLevel.ToArray();
                        foreach (var task in taskArr)
                        {
                            text = task.Importance + "/" + task.TaskContent + "/" + task.Limit;
                            file.WriteLine(text);
                        }
                    }
                }
                //Info?.Invoke("Список задач записан в файл");
            }
        }
        
        //todo
        public static Dictionary<int, ImportanceTable> ReaderFromFail()
        {
            if (File.Exists(FilePath))
            {
                var level = ImportanceTable.CreatTaskList();
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] taskfeld = line.Split('/');
                        var task = new Objective(Int32.Parse(taskfeld[0]), taskfeld[1], taskfeld[2]);
                        level[Int32.Parse(taskfeld[0])].AddTask(task);
                    }
                }
                //Info?.Invoke("Список задач загружен из файла");                
                return level;
            }
            else
            {
                Info?.Invoke("Файл не существует или путь указан неверно");
                return null;
            }
        }      

        public static void ClearFile()
        {
            if (File.Exists(FilePath))
                File.WriteAllText(FilePath, null);
            else  Info?.Invoke("Файл не существует или путь указан неверно");
        }
    }
}