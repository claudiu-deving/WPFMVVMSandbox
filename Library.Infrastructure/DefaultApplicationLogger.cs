using Serilog;

using System.Text;
#nullable enable
namespace Library.Infrastructure.ExceptionHandling;
public class DefaultApplicationLogger : IApplicationLogger
{
    public DefaultApplicationLogger(ILoggingPathsProvider? appPathProvider = null)
    {
        appPathProvider ??= new AppPathsProvider();
        var logsFolder = appPathProvider.GetLogFolder();
        var logFilePath = Path.Combine(logsFolder, "log-.txt");

        _logger = new LoggerConfiguration()
                    .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Month)
                    .CreateLogger();
        Information("=====================================================================");
        Information($"Application started: {DateTime.Now}");
        Information("=====================================================================");
    }

    private readonly ILogger _logger;

    public void Information(string message)
    {
        _logger.Information(message);
    }
    public void Information(Exception exception)
    {
        _logger.Information(BuildMessage(exception).ToString());
    }

    public void Warning(Exception exception)
    {
        _logger.Warning(BuildMessage(exception).ToString());
    }

    public void Error(Exception exception)
    {
        if (exception is null)
        {
            _logger.Error("Exception is null !!");
            return;
        }
        _logger.Error(BuildMessage(exception).ToString(), exception, exception.InnerException);
    }
    private static StringBuilder BuildMessage(Exception exception)
    {
        StringBuilder bobTheBuilder = new();
        // Log the message
        bobTheBuilder.AppendLine("Exception Message: " + exception.Message);

        // Log the inner exception, if it exists
        if (exception.InnerException != null)
        {
            bobTheBuilder.AppendLine("Inner Exception: " + exception.InnerException.Message);
        }

        // Log the stack trace
        bobTheBuilder.AppendLine("Stack Trace: " + exception.StackTrace);

        // If you need to log additional information, you can include it here
        // For example, you might want to log the source or target site
        bobTheBuilder.AppendLine("Exception Source: " + exception.Source);
        bobTheBuilder.AppendLine("Target Site: " + exception.TargetSite);

        // Optionally, log the entire exception object, which includes all properties
        bobTheBuilder.AppendLine("Complete Exception: " + exception.ToString());
        return bobTheBuilder;
    }

    public void OnExit()
    {
        Information("=====================================================================");
        Information($"Application exited: {DateTime.Now}");
        Information("=====================================================================");
    }
}
