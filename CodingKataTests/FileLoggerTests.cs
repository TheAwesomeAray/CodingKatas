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
            var fileLogger = new FileLogger(writer.Object);

            fileLogger.Log(message);

            writer.Verify(x => x.WriteToFile(It.Is<string>(y => y == message)));
        }
    }
}
