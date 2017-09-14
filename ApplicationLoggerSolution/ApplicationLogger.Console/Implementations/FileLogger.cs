
namespace ApplicationLogger.Console.Implementations
{
    using Enums;
    using Interfaces;
    using System;
    using System.Configuration;
    using System.IO;

    public class FileLogger : ILogger
    {
        public FileLogger()
        {
            string directoryPath = ConfigurationManager.AppSettings["LogFileDirectory"];
            VerifyDirectory(directoryPath);
        }

        public void LogMessage(LogMessageType logMessageType, string message)
        {

            string fileName = $"{ConfigurationManager.AppSettings["LogFileDirectory"]}LogFile{DateTime.Now:ddMMyyyy}.txt";

            string text = $"{DateTime.Now.ToShortDateString()} {message} \n";

            try
            {
                File.AppendAllText(fileName, text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void VerifyDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }
    }
}
