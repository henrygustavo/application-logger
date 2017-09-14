namespace ApplicationLogger.Console
{
    using System;
    using Enums;
    using Implementations;

    class Program
    {
        static void Main(string[] args)
        {
            JobLogger jobLogger = new JobLogger();

            jobLogger.AddLogger(new ConsoleLogger());
            jobLogger.AddLogger(new FileLogger());
            //jobLogger.AddLogger(new DataBaseLogger());

            jobLogger.AddMessageType(LogMessageType.Error);
            jobLogger.AddMessageType(LogMessageType.Warning);
            jobLogger.AddMessageType(LogMessageType.Message);

            jobLogger.LogMessage(LogMessageType.Error, "There was un expected error");
            jobLogger.LogMessage(LogMessageType.Warning, "Something is happening in your system");
            jobLogger.LogMessage(LogMessageType.Message, "Just doing a test");

            Console.ReadKey();
        }
    }
}
