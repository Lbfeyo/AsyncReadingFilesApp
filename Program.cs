
Console.WriteLine($"Ввведите путь к директории:");
var task1 = Console.ReadLine();
if (Directory.Exists(task1))
{
    try
    {
        await ProcessFilesAsync(task1);
    }
    catch (Exception e)
    {
        Console.WriteLine($"Ошибка в методе Main : {e.Message}");

    }
}
else
{
    Console.WriteLine("Указанный путь не существует.");
}


async Task ProcessFilesAsync(string directoryPath)
{
    
    try
    {
        var files = Directory.GetFiles(directoryPath, "*.txt");
        if(files.Length == 0) 
        { 
            Console.WriteLine("В директории нет файлов"); 
            return; 
        }
        else 
        { 
            foreach (var file in files)
            {
                var wordCount = await CountWordsInFileAsync(file);
                Console.WriteLine($"Файл: {Path.GetFileName(file)}, Количество слов: {wordCount}");
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Ошибка при выполнении функции ProcessFilesAsync: {e.Message}");
    }

}

async Task<int> CountWordsInFileAsync(string filePath)
{
    try
    {
        var content = await File.ReadAllTextAsync(filePath);
        var words = content.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }
    catch (Exception e)
    {
        Console.WriteLine($"Ошибка при чтении файла {filePath}: {e.Message}");
        return 0; 
    }
}



