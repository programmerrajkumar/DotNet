using Microsoft.Extensions.Logging;
using System.IO;

namespace LoggingFeature.CustomLogging
{
    public class FileLoggerConfiguration
    {
        public int EventId { get; set; }

        public LogLevel LogLevel { get; set; } = LogLevel.Information;

        public string FolderPath { get; set; } = Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Logs")).FullName;

        public bool SplitLogsBasedOnLogLevel { get; set; } = true;
    }
}
