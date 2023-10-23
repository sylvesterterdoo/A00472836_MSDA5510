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
            .WriteTo.File(new JsonFormatter(),
                "ProgAssign1/logs.json",
                LogEventLevel.Information)
            .WriteTo.File("all-.logs",
                rollingInterval: RollingInterval.Day)
            // .MinimumLevel.Debug() // set default minimum level
            .CreateLogger();
    }
}