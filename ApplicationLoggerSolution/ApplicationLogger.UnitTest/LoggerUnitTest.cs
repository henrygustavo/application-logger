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
        private IJobLogger _jobLogger;
        private string _message;

        [TestInitialize]
        public void Setup()
        {
            _jobLogger = new JobLogger();
            _message = "Testing one message";
        }

        [TestMethod]
        public void Add_1Logger_CountLogger_ShouldBe1()
        {
            var mock = new Mock<ILogger>();

            _jobLogger.AddLogger(mock.Object);

            Assert.AreEqual(1, _jobLogger.GetCountLoggers());
        }

        [TestMethod]
        public void Add_1LogMessageType_CountTypeMessages_ShouldBe1()
        {
            _jobLogger.AddMessageType(LogMessageType.Message);

            Assert.AreEqual(1, _jobLogger.GetCountTypeMessages());
        }

        [TestMethod]
        public void Add_Same_LogMessageType_1LogMessageType_ShouldBeAdded()
        {
            _jobLogger.AddMessageType(LogMessageType.Error);
            _jobLogger.AddMessageType(LogMessageType.Error);

            Assert.AreEqual(1, _jobLogger.GetCountTypeMessages());
        }

        [TestMethod]
        public void Add_Same_Logger_1Logger_ShouldBeAdded()
        {
            var mock = new Mock<ILogger>();

            _jobLogger.AddLogger(mock.Object);
            _jobLogger.AddLogger(mock.Object);

            Assert.AreEqual(1, _jobLogger.GetCountLoggers());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void JoLogger_WithoutMessage_ThrowException()
        {

            var mock = new Mock<ILogger>();
            _jobLogger.AddLogger(mock.Object);

            _jobLogger.LogMessage(LogMessageType.Error, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void JoLogger_WithoutLogger_ThrowException()
        {
            _jobLogger.LogMessage(LogMessageType.Error, _message);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void JoLogger_WithoutValidLogMessageType_ThrowException()
        {
            var mock = new Mock<ILogger>();
            _jobLogger.AddLogger(mock.Object);
            _jobLogger.AddMessageType(LogMessageType.Warning);

            _jobLogger.LogMessage(LogMessageType.Error, _message);
        }

        [TestMethod]
        public void JoLogger_WithValidLogMessageType_Logger_Called_Once()
        {
            var mock = new Mock<ILogger>();
            _jobLogger.AddLogger(mock.Object);

            _jobLogger.AddMessageType(LogMessageType.Error);
            _jobLogger.LogMessage(LogMessageType.Error, _message);

            mock.Verify(x => x.LogMessage(LogMessageType.Error, _message), Times.Once);
        }
    }
}