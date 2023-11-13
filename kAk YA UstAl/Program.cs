class Program
{
    static void Main()
    {
        DriveInfo[] drives = FileManager.GetDrives();
        int selectedDriveIndex = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Выберите дисковод:");
            for (int i = 0; i < drives.Length; i++)
            {
                if (i == selectedDriveIndex)
                {
                    Console.Write(">");
                }
                else
                {
                    Console.Write("  ");
                }
                FileManager.DisplayDriveInfo(drives[i]);
            }

            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow && selectedDriveIndex > 0)
            {
                selectedDriveIndex--;
            }
            else if (key.Key == ConsoleKey.DownArrow && selectedDriveIndex < drives.Length - 1)
            {
                selectedDriveIndex++;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                DisplayDriveContents(drives[selectedDriveIndex]);
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                break;
            }
        }
    }

    static void DisplayDriveContents(DriveInfo drive)
    {
        FileSystemInfo[] entries = FileManager.GetFileSystemEntries(drive.Name);

        int selectedEntryIndex = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Содержание {drive.Name}:");
            for (int i = 0; i < entries.Length; i++)
            {
                if (i == selectedEntryIndex)
                {
                    Console.Write(">");
                }
                else
                {
                    Console.Write("  ");
                }
                string type = (entries[i].Attributes & FileAttributes.Directory) == FileAttributes.Directory ? "DIR" : "FILE";
                Console.WriteLine($"[{type}] {entries[i].Name}");
            }

            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow && selectedEntryIndex > 0)
            {
                selectedEntryIndex--;
            }
            else if (key.Key == ConsoleKey.DownArrow && selectedEntryIndex < entries.Length - 1)
            {
                selectedEntryIndex++;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                if ((entries[selectedEntryIndex].Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    DisplayFolderContents(entries[selectedEntryIndex].FullName);
                }
                else
                {
                    FileManager.OpenFile(entries[selectedEntryIndex].FullName);
                }
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                break;
            }
        }
    }

    static void DisplayFolderContents(string path)
    {
        FileSystemInfo[] entries = FileManager.GetFileSystemEntries(path);

        int selectedEntryIndex = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"     Содержание {path}:");
            for (int i = 0; i < entries.Length; i++)
            {
                if (i == selectedEntryIndex)
                {
                    Console.Write(">");
                }
                else
                {
                    Console.Write("  ");
                }
                string type = (entries[i].Attributes & FileAttributes.Directory) == FileAttributes.Directory ? "DIR" : "FILE";
                Console.WriteLine($"[{type}] {entries[i].Name}");
            }

            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow && selectedEntryIndex > 0)
            {
                selectedEntryIndex--;
            }
            else if (key.Key == ConsoleKey.DownArrow && selectedEntryIndex < entries.Length - 1)
            {
                selectedEntryIndex++;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                if ((entries[selectedEntryIndex].Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    DisplayFolderContents(entries[selectedEntryIndex].FullName);
                }
                else
                {
                    FileManager.OpenFile(entries[selectedEntryIndex].FullName);
                }
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                break;
            }
        }
    }


    static void Mainn()
    {
        string filename = "example.txt";

        // Проверка наличия файла перед его открытием
        if (File.Exists(filename))
        {
            string content = File.ReadAllText(filename);
            Console.WriteLine(content);
        }
        else
        {
            Console.WriteLine("File does not exist: " + filename);
        }
    }
}