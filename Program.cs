using System;
using System.Threading.Tasks;
using fileRead;

class Program
{
    // Добавили ключевое слово static, чтобы .NET понимал, что это точка входа
    static async Task Main()
    {
        FileCounter counter = new FileCounter();


        int fileLines = counter.GetLinesCount("Program.cs", ignoreEmptyLines: true);
        Console.WriteLine($"Число заполненных строк в файле: {fileLines}");

        string myProjectPath = @"C:\Users\alohp\Desktop\weaterproject";
        

        int totalProjectLines = counter.GetFolderLinesCount(myProjectPath);
        Console.WriteLine($"Всего строк C# кода во всем проекте: {totalProjectLines}");
        
        int asyncLines = await counter.GetLinesCountAsync("Program.cs");
        Console.WriteLine($"Асинхронный подсчет: {asyncLines}");
    }
}
