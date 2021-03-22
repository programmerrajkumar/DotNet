using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationFeature
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.ConfigureAppConfiguration((hostingContext, configBuilder) =>
                //{

                //    configBuilder.Sources.Clear();

                //    IHostEnvironment env = hostingContext.HostingEnvironment;

                //    configBuilder
                //    .AddJsonFile("appsettings.xml", optional: true, reloadOnChange: true)
                //    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                //    .AddEnvironmentVariables()
                //    .AddKeyPerFile(directoryPath: Path.Combine(Directory.GetCurrentDirectory(), "filepath"), optional: true)
                //    .AddInMemoryCollection(new Dictionary<string, string> { ["Key"] = "Value" });

                //    IConfigurationRoot configurationRoot = configBuilder.Build();
                //    //configurationRoot.Get<string>()

                //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
