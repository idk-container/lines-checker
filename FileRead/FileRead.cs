using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace fileRead
{
    public class FileCounter
    {
        /* 
        Counting lines in one file 
        
        
        */
        public static int GetLinesCount(string path, bool ignoreEmptyLines = false)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"Файл не найден: {path}");
                return 0;
            }

            if (ignoreEmptyLines)
            {
                return File.ReadLines(path).Count(line => !string.IsNullOrWhiteSpace(line));
            }

            return File.ReadLines(path).Count();
        }
        /* 
        Check exist Directory in project
        and check lines in all files
        */
        // Вариант 2: Передавать расширение как параметр метода (по умолчанию любые файлы)
        public static int GetFolderLinesCount(string folderPath, string searchPattern = "*")
        {
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"Папка не найдена: {folderPath}");
                return 0;
            }

            // Используем переменную searchPattern
            string[] files = Directory.GetFiles(folderPath, searchPattern, SearchOption.AllDirectories);

            int totalLines = 0;
            foreach (var file in files)
            {
                totalLines += GetLinesCount(file, ignoreEmptyLines: true);
            }

            return totalLines;
        }


        // Async version for count Lines in code
        public static async Task<int> GetLinesCountAsync(string path)
        {
            if (!File.Exists(path)) return 0;

            int count = 0;
            // Используем StreamReader для асинхронного чтения
            using (var reader = new StreamReader(path))
            {
                while (await reader.ReadLineAsync() != null)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
