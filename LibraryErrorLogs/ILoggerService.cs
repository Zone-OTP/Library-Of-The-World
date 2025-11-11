namespace LibraryErrorLogs
{
    public interface ILoggerService
    {
        Task LogError(Exception ex, string message, params object[] args);
        Task LogInformation(string message, params object[] args);
    }
}
