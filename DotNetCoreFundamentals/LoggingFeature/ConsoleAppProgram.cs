using Microsoft.Extensions.Logging;

namespace LoggingFeature
{
    public class ConsoleAppProgram
    {
        public static void Main1(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(configure =>
            {

                configure
                    .AddConsole()
                    .AddEventLog()
                    .AddDebug()
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning);
            });

            var logger = loggerFactory.CreateLogger<ConsoleAppProgram>();
            logger.LogWarning("Warning Message");
        }
    }
}
