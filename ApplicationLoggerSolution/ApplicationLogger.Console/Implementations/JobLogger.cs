
namespace ApplicationLogger.Console.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Enums;

    public class JobLogger : IJobLogger
    {
        private List<ILogger> _loggers;
        private List<LogMessageType> _logMessageTypes;

        public JobLogger()
        {
            this._loggers = new List<ILogger>();
            this._logMessageTypes = new List<LogMessageType>();
        }

        public JobLogger(List<ILogger> loggers, List<LogMessageType> logMessageTypes)
        {
            this._loggers = loggers ?? new List<ILogger>();
            this._logMessageTypes = logMessageTypes ?? new List<LogMessageType>();
        }

        public void AddLogger(ILogger logger)
        {
            if (logger != null && this._loggers.All(x => x != logger))
            {
                _loggers.Add(logger);
            }
        }

        public int GetCountLoggers()
        {
            return _loggers.Count;
        }

        public void AddMessageType(LogMessageType logMessageType)
        {
            if (this._logMessageTypes.All(x => x != logMessageType))
            {
                this._logMessageTypes.Add(logMessageType);
            }
        }

        public int GetCountTypeMessages()
        {
            return this._logMessageTypes.Count;
        }

        public void LogMessage(LogMessageType logMessageType, string message)
        {
            DoValidation(logMessageType, message);

            foreach (ILogger logger in _loggers)
            {
                logger.LogMessage(logMessageType, message.Trim());
            }
        }

        private void DoValidation(LogMessageType logMessageType, string message)
        {
           
            if (this._loggers.Count == 0)
                throw new Exception("Invalid configuration");

            if (this._logMessageTypes.Count == 0)
                throw new Exception("Error or Warning or Message must be specified");

            if (string.IsNullOrEmpty(message))
            {
                throw new Exception("Message is required");
            }

            if (!this._logMessageTypes.Exists(x => x == logMessageType))
            {
                throw new Exception("The message type that you are using is not allowed");
            }
        }
    }
}
