using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace DotNetCoreFundamentals.CustomStartupFilter
{
    public class StartupFilter1 : IStartupFilter
    {
        private readonly ILogger<StartupFilter1> _logger;

        public StartupFilter1(ILogger<StartupFilter1> logger)
        {
            _logger = logger;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                _logger.LogInformation($"Started {nameof(StartupFilter1)}");
                next(builder);
                _logger.LogInformation($"Ended {nameof(StartupFilter1)}");
            };
        }
    }
}
