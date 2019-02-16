using System;

namespace CodingKatas
{
    public class FileLogger
    {
        private IFileWriter writer;
        private ISystemDate systemDate;
        private string logFileDateTimeFormat = "yyyyMMdd";

        public FileLogger(IFileWriter writer, ISystemDate systemDate)
        {
            this.writer = writer;
            this.systemDate = systemDate;
        }

        public void Log(string message)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("log.txt", true))
            {
                writer.WriteToFile(message, $"log{systemDate.Now().ToString(logFileDateTimeFormat)}.txt");
            }
        }
    }

    public interface ISystemDate
    {
        DateTime Now();
    }

    public interface IFileWriter
    {
        void WriteToFile(string message);
        void WriteToFile(string message, string fileName);
    }
}
