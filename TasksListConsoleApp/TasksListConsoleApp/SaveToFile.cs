using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Reflection;
using System.Collections.Generic;

namespace TasksListConsoleApp
{
    public static class SaveToFile
    {        
        private readonly static string FilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TaskList.txt");
        /*
        public SaveToFile() { }

        public SaveToFile(string path)
        {                        
            try
            {
                FilePath = Path.Combine(path, "TaskList.txt");                
            }
            catch
            {
                throw new Exception("Путь к месту записи файла не найден");
            }
        }*/

        public async static void RecordToFile(Objective task)
        {
            var text = task.Importance + " - " + task.TaskContent + " - " + task.Limit + " \n";
            await File.AppendAllTextAsync(FilePath, text);                   
        }

        public async static void Reader()
        {
            if (File.Exists(FilePath))
            {
                StreamReader reader = new(FilePath);
                Console.WriteLine(await reader.ReadToEndAsync());
                reader.Close();
            }
        }

        public static void ClearFile()
        {
            if (File.Exists(FilePath))
                File.WriteAllText(FilePath, null);                
        }
    }
}