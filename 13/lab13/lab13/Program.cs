using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace lab13
{
    class TADLog
    {
        readonly DateTime dateOfCreation = DateTime.Now;
        public void WriteFile(string action, string filePath = @"F:\University\2 kurs\OOP\13\TADlogfile.txt", string fileName = "ZDAlogfile.txt") // запись файла
        {
            StreamWriter sw = new StreamWriter(filePath, true, Encoding.Default); // Для записи в текстовый файл используется класс StreamWriter
            sw.WriteLine("Имя файла: " + fileName);
            sw.WriteLine("Путь к файлу " + filePath);
            sw.WriteLine("Дата создания: " + dateOfCreation);
            sw.WriteLine(action);
            sw.WriteLine();
            sw.Close();
        }
        public void WriteFile(List<string> action, string filePath = @"F:\University\2 kurs\OOP\13\TADlogfile.txt", string fileName = "ZDAlogfile.txt") // чтение файла
        {
            StreamWriter sw = new StreamWriter(filePath, true, Encoding.Default);
            sw.WriteLine("Имя файла: " + fileName);
            sw.WriteLine("Путь к файлу " + filePath);
            sw.WriteLine("Дата создания: " + dateOfCreation);
            foreach (string item in action)
            {
                sw.WriteLine(item);
            }
            sw.WriteLine();
            sw.Close();
        }
    }
    class TADDiskInfo
    {
        private string actionOne;
        public string FreeSpace()
        {
            DriveInfo[] drives = DriveInfo.GetDrives(); // свободное место на диске
            foreach (DriveInfo drive in drives)
            {
                actionOne = "Свободное место на диске в байтах: " + drive.AvailableFreeSpace.ToString();
            }
            return actionOne;
        }
        public string FileSystem() // файловая система
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                actionOne = "Файловая система: " + drive.DriveFormat.ToString();
            }
            return actionOne;
        }
        public string Disk()
        {
            DriveInfo[] drives = DriveInfo.GetDrives(); // информация о диске
            foreach (DriveInfo drive in drives)
            {
                actionOne = "Имя диска: " + drive.Name + ". ";
                actionOne += "Объём: " + drive.TotalFreeSpace + "байт. ";
                actionOne += "Доступный объём: " + drive.AvailableFreeSpace + "байт. ";
                actionOne += "Метка тома: " + drive.VolumeLabel + ". ";
            }
            return actionOne;
        }
    }
    class TADFileInfo
    {
        private string action;
        public string FullPath(string path = @"F:\University\2 kurs\OOP\13\TADlogfile.txt") // полный путь до файла
        {
            FileInfo f = new FileInfo(path);
            action = "Полный путь к файлу: " + f.DirectoryName;
            return action;
        }
        public string Info(string path = @"F:\University\2 kurs\OOP\13\TADlogfile.txt") // инфа о файле
        {
            FileInfo f = new FileInfo(path);
            action = "Размер: " + f.Length + "байт. ";
            action += "Расширение: " + f.Extension + ". ";
            action += "Имя: " + f.FullName + ". ";
            return action;
        }
        public string Dates(string path = @"F:\University\2 kurs\OOP\13\TADlogfile.txt") // даты создания и изменения
        {
            FileInfo f = new FileInfo(path);
            action = "Дата создания: " + f.CreationTime + ". ";
            action += "Дата изменения: " + f.LastWriteTime + ". ";
            return action;
        }
    }
    class TADDirInfo
    {
        private string action;
        public string AmountOfFiles(string path = @"F:\University\2 kurs\OOP") // кол-во файлов
        {
            int amount = 0;
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                amount++;
            }
            action = "Количество файлов в " + path + ": " + amount;
            return action;
        }
        public string CreateDate(string path = @"F:\University\2 kurs\OOP") // дата создания
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            action = "Дата создания: " + directory.CreationTime;
            return action;
        }
        public string AmountDirs(string path = @"F:\University\2 kurs\OOP") // кол-во директорий
        {
            int amount = 0;
            DirectoryInfo directory = new DirectoryInfo(path);
            DirectoryInfo[] directories = directory.GetDirectories();
            foreach (DirectoryInfo info in directories)
            {
                amount++;
            }
            action = "Количество каталогов: " + amount;
            return action;
        }
        public string Parent(string path = @"F:\University\2 kurs") // родительский директорий
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            action = "Родительский каталог: " + directory.Parent;
            return action;
        }
    }
    class TADFileManager
    {
        private List<string> action = new List<string>();
        public List<string> FilesAndDirsList(string diskName = @"F:\")
        {
            string[] fileList = Directory.GetFiles(diskName);
            action.Add("Файлы: ");
            foreach (string file in fileList)
            {
                action.Add(file);
            }
            string[] dirList = Directory.GetDirectories(diskName);
            action.Add("Папки: ");
            foreach (string dir in dirList)
            {
                action.Add(dir);
            }
            return action;
        }
        public string CreateDir(string path = @"F:\University\2 kurs\OOP\13\TADInspect") // создание директория
        {
            DirectoryInfo newDir = new DirectoryInfo(path);
            if (newDir.Exists)
            {
                newDir.Delete(true);
            }
            newDir.Create();
            return "Создана папка " + path;
        }
        public string CreateFile(string path = @"F:\University\2 kurs\OOP\13\TADInspect\TADdirinfo.txt") // создание файла
        {
            FileStream file = File.Open(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(file, Encoding.Default);
            sw.Write("Hello!");
            sw.Close();
            return "Создан файл " + path;
        }
        public string CopyInfo(string path = @"F:\University\2 kurs\OOP\13\TADInspect\TADdirinfo1.txt") // копирование в новый файл
        {
            StreamWriter sw = new StreamWriter(path, false, Encoding.Default);
            StreamReader sr = new StreamReader(@"F:\University\2 kurs\OOP\13\TADInspect\TADdirinfo.txt");
            sw.WriteLine(sr.ReadLine());
            sr.Close();
            File.Delete(@"F:\University\2 kurs\OOP\13\TADInspect\TADdirinfo.txt");
            return "Произошло копирование в новый файл" + path + "и удаление исходного файла";
        }
        public string CreateDirTwo(string path = @"F:\University\2 kurs\OOP\13\TADFiles") // создание второго директория
        {
            DirectoryInfo newDi = new DirectoryInfo(path);
            if (newDi.Exists)
            {
                newDi.Delete(true);
            }
            newDi.Create();
            return "Создана папка " + path;
        }
        public string CopyFiles(string path = @"F:\University\2 kurs\OOP") // копирование файлов
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] FileList = dir.GetFiles();
            foreach (FileInfo f in FileList)
            {
                if (f.Extension == "txt")
                    f.CopyTo(@"F:\University\2 kurs\OOP\13\TADFiles\");
            }
            return "Произошло копирование файлов";
        }
        public string MoveDir(string path = @"F:\University\2 kurs\OOP\13\TADFiles") // перемещение директория
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            dir.MoveTo(@"F:\University\2 kurs\OOP\13\TADInspect\NewDir");
            return "Произошло перемещение папки";
        }
        public string Zip()
        {
            string sourceFolder = @"F:\University\2 kurs\OOP\13\TADInspect\NewDir\TADFiles";
            string zipFile = @"F:\University\2 kurs\OOP\13\TADFiles.zip";
            string targetFolder = @"F:\University\2 kurs\OOP\13\TADFiles\New";
            ZipFile.CreateFromDirectory(sourceFolder, zipFile); // архивация
            ZipFile.ExtractToDirectory(zipFile, targetFolder); //разархивация
            return "Произошла архивация и разархивация директория";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TADLog log = new TADLog();

                TADDiskInfo diskInfo = new TADDiskInfo();

                log.WriteFile(diskInfo.FreeSpace());
                log.WriteFile(diskInfo.FileSystem());
                log.WriteFile(diskInfo.Disk());

                TADFileInfo fileInfo = new TADFileInfo();

                log.WriteFile(fileInfo.FullPath());
                log.WriteFile(fileInfo.Info());
                log.WriteFile(fileInfo.Dates());

                TADDirInfo dirInfo = new TADDirInfo();

                log.WriteFile(dirInfo.AmountOfFiles());
                log.WriteFile(dirInfo.CreateDate());
                log.WriteFile(dirInfo.AmountDirs());
                log.WriteFile(dirInfo.Parent());

                TADFileManager manager = new TADFileManager();

                log.WriteFile(manager.FilesAndDirsList());
                log.WriteFile(manager.CreateDir());
                log.WriteFile(manager.CreateFile());
                log.WriteFile(manager.CopyInfo());
                log.WriteFile(manager.CreateDirTwo());
                log.WriteFile(manager.CopyFiles());
                log.WriteFile(manager.MoveDir());
            }
            finally
            {
                Console.WriteLine("Записано в файл");
                StreamReader file = new StreamReader(@"F:\University\2 kurs\OOP\13\TADlogfile.txt");
                List<string> str = new List<string>();
                while (true)
                {
                    string st = file.ReadLine();
                    if (st != null)
                        str.Add(st);
                    else
                        break;
                }
                int count = 0;
                IEnumerable<string> OutStr = str.Where(st => st.StartsWith("Дата создания: 25.12.2020"));
                foreach (string i in OutStr)
                {
                    count++;
                }
                Console.WriteLine(count);
            }
        }
    }
}
