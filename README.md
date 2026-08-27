# FileCounter (fileRead)

A lightweight and easy-to-use C# library for **counting lines in files and directories**. It supports filtering out empty lines, recursive folder scanning, and asynchronous file reading.

## ✨ Features

- **Flexible Line Counting:** Count total lines or ignore empty/whitespace lines.
- **Folder Scanning:** Recursively scan directories to count lines across multiple files using search patterns.
- **Async Support:** Asynchronous methods for reading large files without blocking the main thread.
- **Safety Checks:** Built-in validation for missing files and directories.

## 🚀 Code Examples

### 1. Count Lines in a Single File
```csharp
// Synchronous counting, ignoring empty lines
int fileLines = FileCounter.GetLinesCount("Program.cs", ignoreEmptyLines: true);
Console.WriteLine(\$"Число заполненных строк в файле: {fileLines}");
```

### 2. Count Lines in a Whole Folder (Recursive)
```csharp
// Scan all files in a project folder
string myProjectPath = @"C:\Users\alohp\Desktop\weaterproject";
int totalProjectLines = FileCounter.GetFolderLinesCount(myProjectPath);
Console.WriteLine(\$"Всего строк C# кода во всем проекте: {totalProjectLines}");
```

### 3. Asynchronous Counting
```csharp
// Non-blocking async line counter
int asyncLines = await FileCounter.GetLinesCountAsync("Program.cs");
Console.WriteLine(\$"Асинхронный подсчет: {asyncLines}");