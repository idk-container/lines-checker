using System;
using System.Threading.Tasks;
using fileRead;

class Program
{
    static async Task Main()
    {
        int fileLines = FileCounter.GetLinesCount("Program.cs", ignoreEmptyLines: true);
        Console.WriteLine($"Число заполненных строк в файле: {fileLines}");




        string myProjectPath = @"C:\Users\alohp\Desktop\weaterproject";
        int totalProjectLines = FileCounter.GetFolderLinesCount(myProjectPath);
        Console.WriteLine($"Всего строк C# кода во всем проекте: {totalProjectLines}");
        int asyncLines = await FileCounter.GetLinesCountAsync("Program.cs");
        Console.WriteLine($"Асинхронный подсчет: {asyncLines}");
    }
}
