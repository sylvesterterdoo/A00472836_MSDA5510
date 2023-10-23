using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace Assignment1;

public class AppLogger
{
    public static Logger GetAppLoggerFactory()
    {
        return new LoggerConfiguration()
            .WriteTo.Console()
            // add a logging target for warnings and higher severity  logs
            .WriteTo.File(new JsonFormatter(), // structured in JSON format
                "ProgAssign1/logs.json",
                LogEventLevel.Information)
            // add a rolling file for all logs
            .WriteTo.File("all-.logs",
                rollingInterval: RollingInterval.Day)
            // set default minimum level
            // .MinimumLevel.Debug()
            .CreateLogger();
    }
}