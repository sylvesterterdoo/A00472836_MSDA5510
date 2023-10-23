using System;
using System.IO;
using Serilog.Core;

namespace Assignment1;

public class TestProgram
{

    public static void HeMain(string[] args)
    {
        Logger logger = AppLogger.GetAppLoggerFactory();
        logger.Information("Hello world");
    }
    
    
    public static void HelloMain(string[] args)
    {
        var rootPath =
            @"/Users/sly/school-work/Projects/dirCrawler/MCDA5510_Assignments/Assignment1/Assignment1/Sample Data";

        var files = Directory.GetFiles(rootPath, "*", SearchOption.AllDirectories);
        var numOfFile = files.Length; // 13095
        Console.WriteLine($"Number of files {numOfFile}");
        foreach (var file in files)
        {
            var info = new FileInfo(file);
            Console.WriteLine(info.Length);
        }

        var exists = Directory.Exists($"{rootPath}/DeleteFolder");
        
        if (exists) Console.WriteLine("Directory exist");
        else Console.WriteLine("Directory does not exist");


        // Console.WriteLine(Path.GetDirectoryName(file));
        // Console.WriteLine(Path.GetFullPath(file));
        // Console.WriteLine(Path.GetFileNameWithoutExtension(file));
        // Console.WriteLine(Path.GetFileName(file));  // Get file name

        // Read directories in this path
        // var directories = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);
        // var directoriesLength = directories.Length; // 623
        // Console.WriteLine($"Number of Directories {directoriesLength}");
        // foreach (var directory in directories) Console.WriteLine(directory);
    }
}