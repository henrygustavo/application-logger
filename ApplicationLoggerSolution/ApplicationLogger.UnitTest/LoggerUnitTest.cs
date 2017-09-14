
namespace ApplicationLogger.UnitTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Console.Interfaces;
    using Console.Enums;
    using Console.Implementations;
    using Moq;

    [TestClass]
    public class LoggerUnitTest
    {
        private IJobLogger jobLogger;

        [TestInitialize]
        public void Setup()
        {
            jobLogger = new JobLogger();
        }

        [TestMethod]
        public void Add_1Logger_CountLogger_ShouldBe1()
        {
            var mock = new Mock<ILogger>();

            jobLogger.AddLogger(mock.Object);

            Assert.AreEqual(1, jobLogger.GetCountLoggers());
        }

        [TestMethod]
        public void Add_1LogMessageType_CountTypeMessages_ShouldBe1()
        {
            jobLogger.AddMessageType(LogMessageType.Message);

            Assert.AreEqual(1, jobLogger.GetCountTypeMessages());
        }

        [TestMethod]
        public void Add_Same_LogMessageType_1LogMessageType_Added()
        {
            jobLogger.AddMessageType(LogMessageType.Error);
            jobLogger.AddMessageType(LogMessageType.Error);

            Assert.AreEqual(1, jobLogger.GetCountTypeMessages());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void JoLogger_WithoutMessage_ThrowException()
        {

            var mock = new Mock<ILogger>();
            jobLogger.AddLogger(mock.Object);

            jobLogger.LogMessage(LogMessageType.Error, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void JoLogger_WithoutLogger_ThrowException()
        {
            jobLogger.LogMessage(LogMessageType.Error, "test");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void JoLogger_WithoutValidLogMessageType_ThrowException()
        {
            var mock = new Mock<ILogger>();
            jobLogger.AddLogger(mock.Object);
            jobLogger.AddMessageType(LogMessageType.Warning);
            jobLogger.LogMessage(LogMessageType.Error, "test");
        }

        [TestMethod]
        public void JoLogger_WithValidLogMessageType_Logger_Called_Once()
        {
            string message = "test";
            var mock = new Mock<ILogger>();
            jobLogger.AddLogger(mock.Object);
            jobLogger.AddMessageType(LogMessageType.Error);

            jobLogger.LogMessage(LogMessageType.Error, message);

            mock.Verify(x => x.LogMessage(LogMessageType.Error, message), Times.Once);
        }

    }
}
