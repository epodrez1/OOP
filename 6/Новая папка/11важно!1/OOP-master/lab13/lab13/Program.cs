using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace lab13
{
    class ZDALog
    {
        readonly DateTime dateOfCreation = DateTime.Now;
        public void WriteFile(string action, string filePath = @"D:\Учёба\2_курс\прога\lab13\ZDAlogfile.txt", string fileName = "ZDAlogfile.txt")
        {
            StreamWriter sw = new StreamWriter(filePath, true, Encoding.Default);
            sw.WriteLine("Имя файла: " + fileName);
            sw.WriteLine("Путь к файлу " + filePath);
            sw.WriteLine("Дата создания: " + dateOfCreation);
            sw.WriteLine(action);
            sw.WriteLine();
            sw.Close();
        }
        public void WriteFile(List<string> action, string filePath = @"D:\Учёба\2_курс\прога\lab13\ZDAlogfile.txt", string fileName = "ZDAlogfile.txt")
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
    class ZDADiskInfo
    {
        private string actionOne;
        public string FreeSpace()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                actionOne = "Свободное место на диске в байтах: " + drive.AvailableFreeSpace.ToString();
            }
            return actionOne;
        }
        public string FileSystem()
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
            DriveInfo[] drives = DriveInfo.GetDrives();
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
    class ZDAFileInfo
    {
        private string action;
        public string FullPath(string path = @"D:\Учёба\2_курс\прога\lab13\ZDAlogfile.txt")
        {
            FileInfo f = new FileInfo(path);
            action = "Полный путь к файлу: " + f.DirectoryName;
            return action;
        }
        public string Info(string path = @"D:\Учёба\2_курс\прога\lab13\ZDAlogfile.txt")
        {
            FileInfo f = new FileInfo(path);
            action = "Размер: " + f.Length + "байт. ";
            action += "Расширение: " + f.Extension + ". ";
            action += "Имя: " + f.FullName + ". ";
            return action;
        }
        public string Dates(string path = @"D:\Учёба\2_курс\прога\lab13\ZDAlogfile.txt")
        {
            FileInfo f = new FileInfo(path);
            action = "Дата создания: " + f.CreationTime + ". ";
            action += "Дата изменения: " + f.LastWriteTime + ". ";
            return action;
        }
    }
    class ZDADirInfo
    {
        private string action;
        public string AmountOfFiles(string path = @"D:\Учёба\2_курс\прога")
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
        public string CreateDate(string path = @"D:\Учёба\2_курс\прога")
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            action = "Дата создания: " + directory.CreationTime;
            return action;
        }
        public string AmountDirs(string path = @"D:\Учёба\2_курс\прога")
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
        public string Parent(string path = @"D:\Учёба\прога")
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            action = "Родительский каталог: " + directory.Parent;
            return action;
        }
    }
    class ZDAFileManager
    {
        private List<string> action = new List<string>();
        public List<string> FilesAndDirsList(string diskName = @"D:\")
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
        public string CreateDir(string path = @"D:\Учёба\2_курс\прога\lab13\ZDAInspect")
        {
            DirectoryInfo newDir = new DirectoryInfo(path);
            if (newDir.Exists)
            {
                newDir.Delete(true);
            }
            newDir.Create();
            return "Создана папка " + path;
        }
        public string CreateFile(string path = @"D:\Учёба\2_курс\прога\lab13\ZDAInspect\zdadirinfo.txt")
        {
            FileStream file = File.Open(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(file, Encoding.Default);
            sw.Write("Hello!");
            sw.Close();
            return "Создан файл " + path;
        }
        public string CopyInfo(string path = @"D:\Учёба\2_курс\прога\lab13\ZDAInspect\zdadirinfo1.txt")
        {
            StreamWriter sw = new StreamWriter(path, false, Encoding.Default);
            StreamReader sr = new StreamReader(@"D:\Учёба\2_курс\прога\lab13\ZDAInspect\zdadirinfo.txt");
            sw.WriteLine(sr.ReadLine());
            sr.Close();
            File.Delete(@"D:\Учёба\2_курс\прога\lab13\ZDAInspect\zdadirinfo.txt");
            return "Произошло копирование в новый файл" + path + "и удаление исходного файла";
        }
        public string CreateDirTwo(string path = @"D:\Учёба\2_курс\прога\lab13\ZDAFiles")
        {
            DirectoryInfo newDi = new DirectoryInfo(path);
            if (newDi.Exists)
            {
                newDi.Delete(true);
            }
            newDi.Create();
            return "Создана папка " + path;
        }
        public string CopyFiles(string path = @"D:\Учёба\2_курс\прога")
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] FileList = dir.GetFiles();
            foreach (FileInfo f in FileList)
            {
                if (f.Extension == "txt")
                    f.CopyTo(@"D:\Учёба\2_курс\прога\lab13\ZDAFiles\");
            }
            return "Произошло копирование файлов";
        }
        public string MoveDir(string path = @"D:\Учёба\2_курс\прога\lab13\ZDAFiles")
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            dir.MoveTo(@"D:\Учёба\2_курс\прога\lab13\ZDAInspect\NewDir");
            return "Произошло перемещение папки";
        }
        public string Zip()
        {
            string sourceFolder = @"D:\Учёба\2_курс\прога\lab13\ZDAInspect\NewDir\ZDAFiles";
            string zipFile = @"D:\Учёба\2_курс\прога\lab13\ZDAFiles.zip";
            string targetFolder = @"D:\Учёба\2_курс\прога\lab13\ZDAFiles\New";
            ZipFile.CreateFromDirectory(sourceFolder, zipFile);
            ZipFile.ExtractToDirectory(zipFile, targetFolder);
            return "Произошла архивация и разархивация директория";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ZDALog log = new ZDALog();

                ZDADiskInfo diskInfo = new ZDADiskInfo();

                log.WriteFile(diskInfo.FreeSpace());
                log.WriteFile(diskInfo.FileSystem());
                log.WriteFile(diskInfo.Disk());

                ZDAFileInfo fileInfo = new ZDAFileInfo();

                log.WriteFile(fileInfo.FullPath());
                log.WriteFile(fileInfo.Info());
                log.WriteFile(fileInfo.Dates());

                ZDADirInfo dirInfo = new ZDADirInfo();

                log.WriteFile(dirInfo.AmountOfFiles());
                log.WriteFile(dirInfo.CreateDate());
                log.WriteFile(dirInfo.AmountDirs());
                log.WriteFile(dirInfo.Parent());

                ZDAFileManager manager = new ZDAFileManager();

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
                StreamReader file = new StreamReader(@"D:\Учёба\2_курс\прога\lab13\ZDAlogfile.txt");
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
                IEnumerable<string> OutStr = str.Where(st => st.StartsWith("Дата создания: 13.11.2020"));
                foreach (string i in OutStr)
                {
                    count++;
                }
                Console.WriteLine(count);
            }
        }
    }
}
