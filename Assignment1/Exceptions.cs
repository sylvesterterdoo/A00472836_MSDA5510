using System;
using System.IO;
using Serilog.Core;

namespace Assignment1;

public class Exceptions
{
    private static readonly string dataPath =
        @"/Users/sly/school-work/Projects/dirCrawler/MCDA5510_Assignments/Assignment1/Assignment1/testWriteToFile.csv";


    private static readonly Logger Logger = AppLogger.GetAppLoggerFactory();

    private static void HMain()
    {
        // var dataPath = @"testWriteToFile2.csv";
        var sw = OpenStream(dataPath);
        if (sw is null)
            return;
        sw.WriteLine("This is the first line.");
        sw.WriteLine("This is the second line.");
        sw.Close();
    }

    public static StreamWriter OpenStream(string path)
    {
        if (path is null)
        {
            Logger.Information("You did not supply a file path.");
            return null;
        }

        try
        {
            var fs = new FileStream(path, FileMode.CreateNew);
            return new StreamWriter(fs);
        }
        catch (FileNotFoundException)
        {
            Logger.Error("The file or directory cannot be found.");
        }
        catch (DirectoryNotFoundException)
        {
            Logger.Error("The file or directory cannot be found.");
        }
        catch (DriveNotFoundException)
        {
            Logger.Error("The drive specified in 'path' is invalid.");
        }
        catch (PathTooLongException)
        {
            Logger.Error("'path' exceeds the maxium supported path length.");
        }
        catch (UnauthorizedAccessException)
        {
            Logger.Error("You do not have permission to create this file.");
        }
        catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
        {
            Logger.Error("There is a sharing violation.");
        }
        catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80)
        {
            Logger.Error("The file already exists.");
        }
        catch (IOException e)
        {
            Logger.Error($"An exception occurred:\nError code: " +
                         $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
        }

        return null;
    }
}