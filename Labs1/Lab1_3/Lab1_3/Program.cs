using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main(string[] args)
    {
        string[] delete = {".//archive", ".//text_dezip", "text.zip"};
        FileInfo check = new FileInfo(delete[2]);
        if (check.Exists)
        {
            File.Delete(delete[2]);
            try
            {
                Directory.Delete(delete[0], true);
                Directory.Delete(delete[1], true);
            }
            catch
            {}
        }
        else
        {
            DirectoryInfo dirInfo = new DirectoryInfo("archive");
            try
            {
                dirInfo.Create();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        Console.WriteLine("Введите строку для записи в файл:");
        string text = Console.ReadLine();
        string path1 = ".//archive";
        DirectoryInfo dirInfo1 = new DirectoryInfo(path1);
        dirInfo1.Create();
        using (FileStream fstream = new FileStream($"{path1}\\note.txt", FileMode.OpenOrCreate))
        {
            byte[] array = System.Text.Encoding.Default.GetBytes(text);
            fstream.Write(array, 0, array.Length);
            Console.WriteLine("Текст записан в файл");
        }
        Console.WriteLine();
        string zipfile = "text.zip";
        string dezipfolder = ".//text_dezip";
        ZipFile.CreateFromDirectory(path1, zipfile);
        Console.WriteLine($"Папка {path1} архивирована в файл {zipfile}");
        Console.WriteLine();
        FileInfo fileInf = new FileInfo("text.zip");
        if (fileInf.Exists)
        {
            Console.WriteLine("Имя файла: {0}", fileInf.Name);
            Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
            Console.WriteLine("Тип файла: {0}", fileInf.Extension);
            Console.WriteLine("Размер: {0}", fileInf.Length);
        }
        Console.WriteLine("Нажмите Enter, чтобы продолжить...");
        Console.ReadLine();
        DirectoryInfo dirInfo2 = new DirectoryInfo(dezipfolder);
        dirInfo2.Create();
        ZipFile.ExtractToDirectory(zipfile, dezipfolder);
        Console.WriteLine($"Файл {zipfile} распакован в папку {dezipfolder}");
        FileInfo fileInf2 = new FileInfo(".//text_dezip//note.txt");
        if (fileInf.Exists)
        {
            Console.WriteLine("Имя файла: {0}", fileInf2.Name);
            Console.WriteLine("Время создания: {0}", fileInf2.CreationTime);
            Console.WriteLine("Тип файла: {0}", fileInf2.Extension);
            Console.WriteLine("Размер: {0}", fileInf2.Length);
        }
        Console.WriteLine();
        Console.WriteLine("Нажмите Enter, чтобы продолжить...");
        Console.ReadLine();
    }
}
 