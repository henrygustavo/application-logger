# application-logger
application-logger for textFile, console, database C#

On this application , I refactored DraftJobLogger.cs .

In a high level I did the next steps:

a) Create an emum with these message types: Message, Warning,Error.
a) Create an interface ILogger that has the method LogMessage() and this one was implemented by these clases: ConsoleLogger, FileLogger and DataBaseLogger.
b) Create and interface IJobLogger and is implemented by JobLogger. Here we can add the allowed loggers and message types.
c) Add unit test for JobLogger methods.
