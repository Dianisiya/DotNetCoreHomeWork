namespace HomeWork.Logger
{
    using System;
    using System.IO;

    using Microsoft.Extensions.Logging;

    public class FileLogger : ILogger
    {
        private string categoryName;
        private Func<string, LogLevel, bool> filter;
        private string filePath;
        private object locker = new object();

        public FileLogger(string filePath, string categoryName, Func<string, LogLevel, bool> filter)
        {
            this.categoryName = categoryName;
            this.filter = filter;
            this.filePath = filePath;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            var message = formatter(state, exception);

            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            message = $"{ logLevel }: {message}";

            if (exception != null)
            {
                message += Environment.NewLine + Environment.NewLine + exception.ToString();
            }

            lock (this.locker)
            {
                File.AppendAllText(this.filePath + $"/log.{logLevel}.txt", message);
            }
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return (filter == null || filter(categoryName, logLevel));
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}