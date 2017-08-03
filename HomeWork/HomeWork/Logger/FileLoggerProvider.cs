namespace HomeWork.Logger
{
    using System;

    using Microsoft.Extensions.Logging;
    public class FileLoggerProvider: ILoggerProvider
    {
        private readonly Func<string, LogLevel, bool> filter;
        private readonly string filePath;

        public FileLoggerProvider(Func<string, LogLevel, bool> filter, string filePath)
        {
            this.filter = filter;
            this.filePath = filePath;
        }

        public void Dispose()
        {
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(this.filePath, categoryName, this.filter);
        }
    }
}