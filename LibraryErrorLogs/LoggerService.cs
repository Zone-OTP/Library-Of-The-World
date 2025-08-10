using Serilog;
using Serilog.Events;

namespace LibraryErrorLogs
{
    public class LoggerService : ILoggerService
    {
        private readonly ILogger _logger;

        public LoggerService(string nameOfLog)
        {
            Directory.CreateDirectory("logs");

            _logger = new LoggerConfiguration()
                .MinimumLevel.Is(LogEventLevel.Information)
                .WriteTo.Console()
                .WriteTo.File(Path.Combine("logs", $"{nameOfLog}-log.txt"), rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public async Task LogError(Exception ex, string message, params object[] args)
        {
            await Task.Run(() => _logger.Error(ex, message, args));
        }

        public async Task LogInformation(string message, params object[] args)
        {
            await Task.Run(() => _logger.Information(message, args));
        }
    }
}
