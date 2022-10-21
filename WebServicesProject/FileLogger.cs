﻿namespace WebServicesProject
{
    public class FileLogger : ILogger, IDisposable
    {
        private string _filePath;
        private static object _lock = new object();
        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return this;
        }

        public void Dispose() { }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId,
            TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            lock (_lock)
            {
                File.AppendAllText(_filePath, formatter(state, exception) + Environment.NewLine);
            }
        }
    }
}
