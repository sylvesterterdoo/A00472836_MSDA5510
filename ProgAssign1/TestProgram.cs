using System.Collections.Generic;

namespace Assignment1;

public class TestProgram
{
    private const string InputDataPath =
        @"/Users/sly/school-work/Projects/SUBMIT/Assignment/ProgAssign1/Sample Data/2018/1/30";

    private const string OutputDataPath = @"../../../Output/customersFile.csv";

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
        WriteCustomerInfoToCsvFile(dirWalker.SimpleCsvParser.CustomerInfos);
        writeToFileTimer.Stop();
        // end write to file

        totalTimer.Stop();

        logger.Information($"Total execution time: {totalTimer.ElapsedTimeInMs}ms");
        logger.Information($"Total number of valid rows: {dirWalker.SimpleCsvParser.ValidRows}");
        logger.Information($"Total number of skipped rows: {dirWalker.SimpleCsvParser.SkippedRows}");
        logger.Information($"Total time to write to file: {writeToFileTimer.ElapsedTimeInMs}ms");
    }


    private static void WriteCustomerInfoToCsvFile(List<CustomerInfo> customersInfo)
    {
        var streamWriter = Exceptions.OpenStream(OutputDataPath);
        if (streamWriter is null)
            return;
        streamWriter.WriteLine(CustomerInfo.GetCustomerInfoCsvHeaders());
        foreach (var customerInfo in customersInfo)
            streamWriter.WriteLine(customerInfo.CustomerInfoToCsv());

        streamWriter.Close();
    }
}