using System.IO;
using Serilog.Core;

namespace Assignment1;
/* TODO:
 * 1. Enter all the data into a single file
 * 2. Log the amount of time it takes to read the files in each directory
 * 3. Log the time it takes to write the files(all) to a file using the logger
 *
 * @"/Users/sly/school-work/Projects/dirCrawler/MCDA5510_Assignments/ProgAssign1/ProgAssign1/Sample Data/";
 */

public class DirWalker
{
    // private readonly Exceptions _exceptions = new();

    private readonly Logger _logger = AppLogger.GetAppLoggerFactory();

    public readonly SimpleCSVParser SimpleCsvParser = new();

    public void Walk(string path)
    {
        var list = Directory.GetDirectories(path);

        if (list == null) return;

        foreach (var dirpath in list)
            if (Directory.Exists(dirpath))
            {
                _logger.Information($"Dir: {dirpath}");
                Walk(dirpath);
            }

        // start reading here. 
        var timer = new Timer();
        timer.Start();

        var fileList = Directory.GetFiles(path);
        foreach (var filepath in fileList) SimpleCsvParser.Parse(filepath);

        // stop reading here.
        timer.Stop();
        _logger.Information($"Finished reading CSVs in {Path.GetFullPath(path)}: {timer.ElapsedTimeInMs}ms");
    }
}