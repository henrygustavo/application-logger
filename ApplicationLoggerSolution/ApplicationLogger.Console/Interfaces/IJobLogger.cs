namespace ApplicationLogger.Console.Interfaces
{
    using Enums;

    /// <summary>
    /// 
    /// </summary>
    public interface IJobLogger
    {
        void AddLogger(ILogger logger);

        int GetCountLoggers();

        void AddMessageType(LogMessageType logMessageType);

        int GetCountTypeMessages();

        void LogMessage(LogMessageType logMessageType, string message);
    }
}
