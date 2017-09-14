namespace ApplicationLogger.Console.Interfaces
{
    using Enums;

    /// <summary>
    /// 
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logMessageType"></param>
        /// <param name="message"></param>
        void LogMessage(LogMessageType logMessageType, string message);
    }
}
