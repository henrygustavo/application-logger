namespace ApplicationLogger.Console.Interfaces
{
    using Enums;

    /// <summary>
    /// interface for loggers
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// this method allows to write a log
        /// </summary>
        /// <param name="logMessageType">type of the log: error,message,warning</param>
        /// <param name="message">log message</param>
        void LogMessage(LogMessageType logMessageType, string message);
    }
}
