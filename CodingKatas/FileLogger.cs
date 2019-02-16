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
            writer.WriteToFile(message, GetFileName());
        }

        private string GetFileName()
        {
            if (systemDate.Now().DayOfWeek == DayOfWeek.Saturday
                || systemDate.Now().DayOfWeek == DayOfWeek.Sunday)
                return "weekend.txt";

            return $"log{systemDate.Now().ToString(logFileDateTimeFormat)}.txt";
        }
    }

    public class SystemDate : ISystemDate
    {
        public DateTime Now() => DateTime.UtcNow;
    }

    public class FileWriter : IFileWriter
    {
        public void WriteToFile(string message, string fileName)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, true))
            {
                file.WriteLine(message);
            }
        }
    }

    public interface ISystemDate
    {
        DateTime Now();
    }

    public interface IFileWriter
    {
        void WriteToFile(string message, string fileName);
    }
}
