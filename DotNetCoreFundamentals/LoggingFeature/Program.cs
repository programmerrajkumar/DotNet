using LoggingFeature.CustomLogging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace LoggingFeature
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.AddFileLogger();
                    logging.AddFileLogger(config => { config.SplitLogsBasedOnLogLevel = false; });
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseWebRoot("Logs");
                });
        // .ConfigureLogging(logging =>
        //        {
        //    logging.ClearProviders();
        //    logging.AddConsole();
        //    logging.AddDebug();
        //    logging.AddEventSourceLogger();
        //    logging.AddEventLog(settings =>
        //    {
        //        settings.MachineName = "Server-1";
        //        settings.SourceName = "My App";
        //    });

        //    logging.SetMinimumLevel(LogLevel.Warning);

        //    logging.AddFilter((provider, category, logLevel) =>
        //    {
        //        if (provider.Contains("ConsoleLoggerProvider") && category.Contains("OrderPlacement") && logLevel >= LogLevel.Information)
        //            return true;

        //        return false;
        //    });
        //})
    }
}
