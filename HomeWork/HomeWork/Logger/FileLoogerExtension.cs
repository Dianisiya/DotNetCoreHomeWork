namespace HomeWork.Logger
{
    using System;

    using Microsoft.Extensions.Logging;

    public static class FileLoogerExtension
    {
        public static ILoggerFactory AddFile(
            this ILoggerFactory factory,
            string filePath,
            Func<string, LogLevel, bool> filter = null)
        {
            factory.AddProvider(new FileLoggerProvider(filter, filePath));
            return factory;
        }
    }
}