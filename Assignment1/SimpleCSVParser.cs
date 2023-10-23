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


    public void parse(string fileName)
    {
        var debugFile =
            "/Users/sly/school-work/Projects/dirCrawler/MCDA5510_Assignments/Assignment1/Assignment1/Sample Data/2018/1/1/CustomerData3.csv";
        if (fileName.Equals(debugFile)) _logger.Information("Debug");

        try
        {
            using (var parser = new TextFieldParser(fileName))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                var lineCount = 1;
                while (!parser.EndOfData)
                {
                    //Process row
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
        catch (IOException ioe)
        {
            _logger.Information("File doesn't exist");
            _logger.Debug(ioe.StackTrace);
        }
    }
}