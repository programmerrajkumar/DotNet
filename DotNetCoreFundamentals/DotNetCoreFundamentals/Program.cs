using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace DotNetCoreFundamentals
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<HostOptions>(option =>
                    {
                        //overrides timeout for sent to cancellation Token of STOPAsync function
                        option.ShutdownTimeout = System.TimeSpan.FromSeconds(10);
                    });
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseStartup<Startup>()
                    .CaptureStartupErrors(true)
                    .UseSetting(WebHostDefaults.DetailedErrorsKey, "true")
                    .UseEnvironment(Microsoft.AspNetCore.Hosting.EnvironmentName.Development)
                    .UseSetting("https_port", "8080");
                });
    }
}
