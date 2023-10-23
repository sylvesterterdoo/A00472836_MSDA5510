using System.IO;
using Serilog.Core;

// using Microsoft.Extensions.Logging;

namespace Assignment1;
/* TODO:
 * 1. update readme file
 * 2. use logging for both info and all possible checked exceptions
 * 3. line with incomplete record should be ignored and logged.
 * 4. The program must use the CSV library
 * 5. In the end your program should log
 *    - Total execution time
 *    - Total number of valid rows.
 *    - Total number of skipped rows.
 * 6. submit result file to directory "Output" in the repo.
 * 7. Data columns First Name, Last Name, Street Number, Street, City Provice,
 *    Country, Postal Code, Phone Number, Email Address
 * 8. Add the date to the defined in the directory structure as a Date data column
 *    (yyyy/mm/dd)
 * 9. submit repo and vs code solution in github
 *
 *
 * README:
 * 1. Enter all the data into a single file
 * 2. Log the amount of time it takes to read the files in each directory
 * 3. Log the time it takes to write the files(all) to a file using the logger
 *
 * @"/Users/sly/school-work/Projects/dirCrawler/MCDA5510_Assignments/Assignment1/Assignment1/Sample Data/";
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