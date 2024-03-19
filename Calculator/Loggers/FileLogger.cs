
namespace Calculator.Backend.Loggers
{
    public class FileLogger : ILogger, IDisposable
    {
        private string _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull 
            => this;

        public void Dispose() {}

        public bool IsEnabled(LogLevel logLevel) 
            => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var logMessage = $"{DateTime.Now}\t{logLevel}\t{formatter(state, exception)}{Environment.NewLine}";
            File.AppendAllText(_filePath, logMessage);
        }
    }
}
