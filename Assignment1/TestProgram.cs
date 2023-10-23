using System.Collections.Generic;

namespace Assignment1;

public class TestProgram
{
    private const string OutputDataPath =
        @"/Users/sly/school-work/Projects/SUBMIT/ProgAssign1/Assignment1/customersFile.csv";

    private const string InputDataPath =
        @"/Users/sly/school-work/Projects/SUBMIT/ProgAssign1/Assignment1/Sample Data/";

    public static void Main(string[] args)
    {
        var logger = AppLogger.GetAppLoggerFactory();

        var totalTimer = new Timer();
        var writeToFileTimer = new Timer();

        var dirWalker = new DirWalker();

        totalTimer.Start();
        dirWalker.Walk(InputDataPath);

        // write to file
        writeToFileTimer.Start();
        WriteToFile(dirWalker.SimpleCsvParser.CustomerInfos);
        writeToFileTimer.Stop();
        // end write to file

        totalTimer.Stop();

        logger.Information($"Total execution time: {totalTimer.ElapsedTimeInMs}ms");
        logger.Information($"Total number of valid rows: {dirWalker.SimpleCsvParser.ValidRows}");
        logger.Information($"Total number of skipped rows: {dirWalker.SimpleCsvParser.SkippedRows}");
        logger.Information($"Total time to write to file: {writeToFileTimer.ElapsedTimeInMs}ms");
    }


    private static void WriteToFile(List<CustomerInfo> customersInfo)
    {
        var streamWriter = Exceptions.OpenStream(OutputDataPath);
        if (streamWriter is null)
            return;
        foreach (var customerInfo in customersInfo)
            streamWriter.WriteLine(customerInfo.CustomerInfoToCsv());

        streamWriter.Close();
    }
}