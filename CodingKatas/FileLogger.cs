using System;

namespace CodingKatas
{
    public class FileLogger
    {
        private IFileWriter writer;
        private ISystemDate date;

        public FileLogger(IFileWriter writer, ISystemDate date)
        {
            this.writer = writer;
            this.date = date;
        }

        public void Log(string message)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("log.txt", true))
            {
                writer.WriteToFile(message);
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
    }
}
