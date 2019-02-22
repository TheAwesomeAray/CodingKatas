using System;

namespace CodingKatas
{
    public class FileLogger
    {
        private IFileWriter writer;
        private ISystemDate systemDate;
        private readonly string logFileDateTimeFormat = "yyyyMMdd";
        private readonly string weekendLogName = "weekend.txt";

        public FileLogger(IFileWriter writer, ISystemDate systemDate)
        {
            this.writer = writer;
            this.systemDate = systemDate;
        }

        public void Log(string message)
        {
            if (IsWeekEnd())
            {
                if (writer.FileExists("weekend.txt"))
                {
                    var createdDate = writer.GetCreationTime(weekendLogName);
                    writer.Move("weekend.txt", $"weekend-{createdDate.ToString(logFileDateTimeFormat)}.txt");
                }
            }

            writer.WriteToFile(message, GetFileName());
        }

        private string GetFileName()
        {
            if (IsWeekEnd())
                return weekendLogName;
            
            return $"log{systemDate.Now().ToString(logFileDateTimeFormat)}.txt";
        }

        private bool IsWeekEnd() => systemDate.Now().DayOfWeek == DayOfWeek.Saturday || 
                                    systemDate.Now().DayOfWeek == DayOfWeek.Sunday;
    }

    public class SystemDate : ISystemDate
    {
        public DateTime Now() => DateTime.UtcNow;
    }

    public class FileWriter : IFileWriter
    {
        public bool FileExists(string filePath)
        {
            throw new NotImplementedException();
        }

        public DateTime GetCreationTime(string filePath)
        {
            throw new NotImplementedException();
        }

        public void Move(string oldPath, string newPath)
        {
            throw new NotImplementedException();
        }

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
        void WriteToFile(string message, string filePath);
        bool FileExists(string filePath);
        DateTime GetCreationTime(string filePath);
        void Move(string oldPath, string newPath);
    }
}
