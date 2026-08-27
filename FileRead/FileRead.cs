using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace fileRead
{
    // 1. Правильное объявление интерфейса
    public interface IFilesMethods 
    {
        int GetLinesCount(string path, bool ignoreEmptyLines = false);
        int GetFolderLinesCount(string folderPath, string searchPattern = "*");
        Task<int> GetLinesCountAsync(string path);
    }

    // 2. Класс реализует интерфейс (убрали static)
    public class FileCounter : IFilesMethods
    {
        private static readonly string[] IncludeFiles = 
        { 
            "README.md", 
            "_build/dev/x.ex", 
            "node_modules/pkg/index.js", 
            "lib/a.ex", 
            "lib/b.exs" 
        };

        // Метод стал экземплярным (public int вместо public static int)
        public int GetLinesCount(string path, bool ignoreEmptyLines = false)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"Файл не найден: {path}");
                return 0;
            }

            bool isIncluded = IncludeFiles.Any(inc => path.Replace('\\', '/').EndsWith(inc, StringComparison.OrdinalIgnoreCase));

            if (!isIncluded)
            {
                return 0; 
            }

            if (ignoreEmptyLines)
            {
                return File.ReadLines(path).Count(line => !string.IsNullOrWhiteSpace(line));
            }
            
            return File.ReadLines(path).Count();
        }

        public int GetFolderLinesCount(string folderPath, string searchPattern = "*")
        {
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"Папка не найдена: {folderPath}");
                return 0;
            }

            string[] files = Directory.GetFiles(folderPath, searchPattern, SearchOption.AllDirectories);

            int totalLines = 0;
            foreach (var file in files)
            {
                // Вызываем метод через текущий экземпляр (или просто по имени)
                totalLines += GetLinesCount(file, ignoreEmptyLines: true);
            }

            return totalLines;
        }

        public async Task<int> GetLinesCountAsync(string path)
        {
            if (!File.Exists(path)) return 0;

            int count = 0;
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
