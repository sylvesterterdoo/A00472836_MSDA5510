using System;
using System.IO;
using Serilog.Core;

namespace Assignment1;

public class Exceptions
{
    private static readonly Logger Logger = AppLogger.GetAppLoggerFactory();

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