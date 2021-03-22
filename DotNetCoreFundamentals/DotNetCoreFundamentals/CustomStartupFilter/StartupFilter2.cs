using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace DotNetCoreFundamentals.CustomStartupFilter
{
    public class StartupFilter2 : IStartupFilter
    {
        private readonly ILogger<StartupFilter2> _logger;

        public StartupFilter2(ILogger<StartupFilter2> logger)
        {
            _logger = logger;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                _logger.LogInformation($"Started {nameof(StartupFilter2)}");
                next(builder);
                _logger.LogInformation($"Ended {nameof(StartupFilter2)}");
            };
        }
    }
}
