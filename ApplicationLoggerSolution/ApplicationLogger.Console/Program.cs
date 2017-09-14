namespace ApplicationLogger.Console
{
    using System;
    using System.Collections.Generic;
    using Enums;
    using Implementations;
    using Interfaces;

    class Program
    {
        static void Main(string[] args)
        {
            List<ILogger> loggers = new List<ILogger> { new DataBaseLogger(), new ConsoleLogger(), new FileLogger() };

            List<LogMessageType> logMessageTypes = new List<LogMessageType> { LogMessageType.Error, LogMessageType.Warning, LogMessageType.Message };

            JobLogger jobLogger = new JobLogger(loggers, logMessageTypes);

            jobLogger.LogMessage(LogMessageType.Error, "There was un expected error");

            jobLogger.LogMessage(LogMessageType.Warning, "Something is happening in your system");

            jobLogger.LogMessage(LogMessageType.Message, "Just doing a test");

            Console.ReadKey();
        }
    }
}
