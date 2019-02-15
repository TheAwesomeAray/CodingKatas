namespace CodingKatas
{
    public class FileLogger
    {
        private IFileWriter writer;

        public FileLogger(IFileWriter writer)
        {
            this.writer = writer;
        }

        public void Log(string message)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("log.txt", true))
            {
                writer.WriteToFile(message);
            }
        }
    }

    public interface IFileWriter
    {
        void WriteToFile(string message);
    }
}
