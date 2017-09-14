namespace ApplicationLogger.Console.Interfaces
{
    using Enums;

    /// <summary>
    /// main interface to log messages 
    /// </summary>
    public interface IJobLogger
    {
        /// <summary>
        /// add logger to jobLogger
        /// </summary>
        /// <param name="logger">logger interface</param>
        void AddLogger(ILogger logger);

        /// <summary>
        /// method to get number of  registered loggers
        /// </summary>
        /// <returns>number of loggers</returns>
        int GetCountLoggers();

        /// <summary>
        /// method to add allowed message types
        /// </summary>
        /// <param name="logMessageType">enum message type</param>
        void AddMessageType(LogMessageType logMessageType);

        /// <summary>
        /// method to get number of registered message types
        /// </summary>
        /// <returns>number of registered message types</returns>
        int GetCountTypeMessages();

        /// <summary>
        /// method to log a message
        /// </summary>
        /// <param name="logMessageType">enum message type</param>
        /// <param name="message">message</param>
        void LogMessage(LogMessageType logMessageType, string message);
    }
}
