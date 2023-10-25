using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using Serilog.Core;

namespace Assignment1;

public class SimpleCSVParser
{
    // private static readonly ILogger<SimpleCSVParser> Logger =
    //     AppLogger.GetAppLoggerFactory().CreateLogger<SimpleCSVParser>();

    private readonly Logger _logger = AppLogger.GetAppLoggerFactory();


    public SimpleCSVParser(int skippedRows = 0, int validRows = 0)
    {
        SkippedRows = skippedRows;
        ValidRows = validRows;
        CustomerInfos = new List<CustomerInfo>();
    }

    public int SkippedRows { get; set; }

    public int ValidRows { get; set; }

    public List<CustomerInfo> CustomerInfos { get; set; }


    public void Parse(string fileName)
    {
        /*
        var debugFile =
            "/Users/sly/school-work/Projects/dirCrawler/MCDA5510_Assignments/ProgAssign1/ProgAssign1/Sample Data/2018/1/1/CustomerData3.csv";
        if (fileName.Equals(debugFile)) _logger.Information("Debug");
        */

        try
        {
            using (var parser = new TextFieldParser(fileName))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                var lineCount = 1;
                while (!parser.EndOfData)
                {
                    // Process file row
                    var fields = parser.ReadFields();
                    if (lineCount != 1)
                    {
                        var customerInfo = CustomerInfo.CreateCustomerInfo(fields);

                        if (customerInfo == null)
                        {
                            SkippedRows += 1;
                            _logger.Information("Skipped record");
                        }
                        else
                        {
                            customerInfo.Date = getCsvFileDate(fileName);
                            CustomerInfos.Add(customerInfo);
                            ValidRows += 1;
                        }
                    }
                    else
                    {
                        lineCount += 1;
                    }
                }
            }
        }
        catch (IOException ioException)
        {
            _logger.Information("File doesn't exist");
            _logger.Debug(ioException.StackTrace);
        }
    }

    private string getCsvFileDate(string filePath)
    {
        var dirSeparatorChar = Path.DirectorySeparatorChar;
        // var date = Path.GetDirectoryName(fileName).Split(dirSeparatorChar);
        string date = null;
        var directoryName = Path.GetDirectoryName(filePath);
        if (directoryName != null)
        {
            var dirPath = directoryName.Split(dirSeparatorChar);
            var length = dirPath.Length;
            if (dirPath.Length >= 3)
            {
                var year = dirPath[length - 3];
                var month = dirPath[length - 2];
                var day = dirPath[length - 1];
                date = $"{year}/{month}/{day}";
            }
        }

        return date;
    }
}