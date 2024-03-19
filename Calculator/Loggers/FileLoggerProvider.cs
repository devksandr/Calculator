namespace Calculator.Backend.Loggers
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private string _filePath;

        public FileLoggerProvider(string filePath)
        {
            _filePath = filePath;
        }

        public ILogger CreateLogger(string categoryName) 
            => new FileLogger(_filePath);

        public void Dispose() {}
    }
}
