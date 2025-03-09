using Terceros.Applications.Interfaces.ICommon;

namespace Terceros.Applications.Interactors.Common;

public class LogServices : ILogServices
{
    private readonly string _logFilePath;
    public LogServices(string logFilePath)
    {
        _logFilePath = logFilePath;

        if (!File.Exists(_logFilePath))
        {
            File.Create(_logFilePath).Dispose();
        }
    }
    public void LogError(string message)
    {
        string logMessage = $"ERROR: {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
        File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
    }
    public void LogTrace(string message)
    {
        string logMessage = $"TRACE: {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
        File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
    }
}
