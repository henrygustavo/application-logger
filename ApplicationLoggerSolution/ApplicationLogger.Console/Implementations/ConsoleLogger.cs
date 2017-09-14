namespace ApplicationLogger.Console.Implementations
{
    using Enums;
    using Interfaces;
    using System;

    public class ConsoleLogger: ILogger
    {
        public void LogMessage(LogMessageType logMessageType, string message)
        {
            switch (logMessageType)
            {
                case LogMessageType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
               
                case LogMessageType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case LogMessageType.Message:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

            }

            Console.WriteLine($"{DateTime.Now.ToShortDateString()} {message}");
        }
    }
}
