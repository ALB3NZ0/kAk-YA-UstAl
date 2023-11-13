using System;
using System.IO;
using System.Linq;

public static class FileManager
{
    public static DriveInfo[] GetDrives()
    {
        return DriveInfo.GetDrives();
    }

    public static void DisplayDriveInfo(DriveInfo drive)
    {
        Console.WriteLine($"{drive.Name} - {drive.TotalSize - drive.TotalFreeSpace} bytes used of {drive.TotalSize} bytes");
    }

    public static FileSystemInfo[] GetFileSystemEntries(string path)
    {
        try
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            return directory.GetFileSystemInfos();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new FileSystemInfo[0];
        }
    }

    public static void DisplayFileSystemEntries(FileSystemInfo[] entries)
    {
        foreach (var entry in entries)
        {
            string type = (entry.Attributes & FileAttributes.Directory) == FileAttributes.Directory ? "DIR" : "FILE";
            Console.WriteLine($"[{type}] {entry.Name}");
        }
    }

    public static void OpenFile(string filePath)
    {
        try
        {
            System.Diagnostics.Process.Start(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}