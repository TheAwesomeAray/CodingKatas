using CodingKatas;
using Moq;
using System;
using System.IO;
using Xunit;

namespace CodingKataTests
{
    public class FileLoggerTests
    {
        public class UnitTests
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

            [Theory]
            [InlineData(1970, 12, 31, "log19701231.txt")]
            [InlineData(1999, 05, 25, "log19990525.txt")]
            [InlineData(2025, 1, 01, "log20250101.txt")]
            public void Log_Message_AppendsDateToFileName(int year, int month, int day, string expected)
            {
                var writer = new Mock<IFileWriter>();
                var date = new Mock<ISystemDate>();
                date.Setup(x => x.Now()).Returns(new DateTime(year, month, day));
                var fileLogger = new FileLogger(writer.Object, date.Object);

                fileLogger.Log("");

                writer.Verify(x => x.WriteToFile(It.IsAny<string>(), It.Is<string>(y => y == expected)));
            }

            [Theory]
            [InlineData(2019, 02, 16)]
            [InlineData(2019, 02, 17)]
            [InlineData(2019, 08, 24)]
            public void Log_MessageOnWeekend_FileNamedWeekendDotTxt(int year, int month, int day)
            {
                var writer = new Mock<IFileWriter>();
                var date = new Mock<ISystemDate>();
                date.Setup(x => x.Now()).Returns(new DateTime(year, month, day));
                var fileLogger = new FileLogger(writer.Object, date.Object);

                fileLogger.Log("");

                writer.Verify(x => x.WriteToFile(It.IsAny<string>(), It.Is<string>(y => y == "weekend.txt")));
            }
        }

        public class IntegrationsTests : IDisposable
        {
            [Fact]
            public void Log_Message_WritesMessageToFile()
            {
                var date = new Mock<ISystemDate>();
                date.Setup(x => x.Now()).Returns(new DateTime(1999, 05, 25));
                var fileLogger = new FileLogger(new FileWriter(), date.Object);

                fileLogger.Log("");

                Assert.True(File.Exists("log19990525.txt"));
            }

            public void Dispose()
            {
                if (File.Exists("log19990525.txt"))
                    File.Delete("log19990525.txt");
            }
        }
    }
}
