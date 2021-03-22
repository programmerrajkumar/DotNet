using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace LoggingFeature.CustomLogging
{
    [ProviderAlias("File")]
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly FileLoggerConfiguration config;
        private ConcurrentDictionary<string, ILogger> _loggers;

        public FileLoggerProvider(FileLoggerConfiguration config)
        {
            _loggers = new ConcurrentDictionary<string, ILogger>();
            this.config = config;
        }

        public ILogger CreateLogger(string categoryName)
           => _loggers.GetOrAdd(categoryName, new FileLogger(categoryName, config));

        public void Dispose()
        {
            _loggers = null;
        }
    }
}
