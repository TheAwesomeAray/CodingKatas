using CodingKatas;
using Moq;
using System;
using System.IO;
using Xunit;

namespace CodingKatas
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

            [Fact]
            public void Log_MessageOnWeekend_RenameOldWeekendDotTxt()
            {
                var writer = new Mock<IFileWriter>();
                var date = new Mock<ISystemDate>();
                writer.Setup(w => w.FileExists(It.IsAny<string>())).Returns(true);
                writer.Setup(w => w.GetCreationTime(It.IsAny<string>())).Returns(new DateTime(2019, 2, 9));
                date.Setup(x => x.Now()).Returns(new DateTime(2019, 08, 24));
                var fileLogger = new FileLogger(writer.Object, date.Object);

                fileLogger.Log("");

                writer.Verify(w => w.Move(It.Is<string>(y => y == "weekend.txt"), 
                    It.Is<string>(y => y == "weekend-20190209.txt")));
            }
        }

        public class IntegrationsTests : IDisposable
        {
            private readonly string logToCreate = "log19990525.txt";

            [Fact]
            public void Log_Message_WritesMessageToFile()
            {
                var date = new Mock<ISystemDate>();
                date.Setup(x => x.Now()).Returns(new DateTime(1999, 05, 25));
                var fileLogger = new FileLogger(new FileWriter(), date.Object);

                fileLogger.Log("");

                Assert.True(File.Exists(logToCreate));
            }

            public void Dispose()
            {
                if (File.Exists(logToCreate))
                    File.Delete(logToCreate);
            }
        }
    }
}
