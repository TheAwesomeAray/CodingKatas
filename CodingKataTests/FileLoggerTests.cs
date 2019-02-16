using CodingKatas;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodingKataTests
{
    public class FileLoggerTests
    {
        [Fact]
        public void Log_Message_WritesMessageToFile()
        {
            string message = "test message";
            var writer = new Mock<IFileWriter>();
            var date = new Mock<ISystemDate>();
            var fileLogger = new FileLogger(writer.Object, date.Object);

            fileLogger.Log(message);

            writer.Verify(x => x.WriteToFile(It.Is<string>(y => y == message), It.IsAny<string>()));
        }

        [Fact]
        public void Log_Message_AppendsDateToFileName()
        {
            var writer = new Mock<IFileWriter>();
            var date = new Mock<ISystemDate>();
            date.Setup(x => x.Now()).Returns(new DateTime(1999, 05, 25));
            var fileLogger = new FileLogger(writer.Object, date.Object);

            fileLogger.Log("");

            writer.Verify(x => x.WriteToFile(It.IsAny<string>(), It.Is<string>(y => y == "log19990525.txt")));
        }
    }
}
