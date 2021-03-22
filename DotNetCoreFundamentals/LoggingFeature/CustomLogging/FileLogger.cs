using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;

namespace LoggingFeature.CustomLogging
{
    public class FileLogger : ILogger
    {
        private readonly string _name;
        private readonly FileLoggerConfiguration _configuration;
        private string _loggingScope;
        public FileLogger(string name, FileLoggerConfiguration configuration)
        {
            _name = name;
            _configuration = configuration;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            _loggingScope = JsonConvert.SerializeObject(state);

            return new FileLoggerScope(this);
        }

        public bool IsEnabled(LogLevel logLevel) => logLevel >= _configuration.LogLevel;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;
            string fullFilePath, logRecord;
            if (_configuration.SplitLogsBasedOnLogLevel)
            {
                fullFilePath = Path.Combine(_configuration.FolderPath, $"{logLevel.ToString()}.txt");
                logRecord = string.Format("[{0}]:[{1}]  -> {2}\n\t{3}\n\t{4}\n\t{5}", _name, eventId, DateTimeOffset.UtcNow.ToString("yyyy-MM-dd HH:mm:ss+00:00"), _loggingScope, formatter(state, exception), exception?.StackTrace ?? "");
            }
            else
            {
                fullFilePath = Path.Combine(_configuration.FolderPath, $"Log.txt");
                logRecord = string.Format("[{0}]:\t[{1}][{2}]  -> {3}\n\t{4}\n\t{5}\n\t{6}", logLevel.ToString(), _name, eventId, DateTimeOffset.UtcNow.ToString("yyyy-MM-dd HH:mm:ss+00:00"), _loggingScope, formatter(state, exception), exception?.StackTrace ?? "");
            }


            using (var streamWriter = File.AppendText(fullFilePath))
            {
                streamWriter.WriteLine(logRecord);
            }
        }

        private class FileLoggerScope : IDisposable
        {
            private readonly FileLogger logger;

            public FileLoggerScope(FileLogger logger)
            {
                this.logger = logger;
            }

            public void Dispose()
            {
                logger._loggingScope = null;
            }
        }
    }
}
