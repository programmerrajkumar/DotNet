using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareFeature.Middleware
{
    public class FactoryActivatedMiddleware : IMiddleware
    {
        private readonly ILogger<FactoryActivatedMiddleware> _logger;

        public FactoryActivatedMiddleware(ILogger<FactoryActivatedMiddleware> logger)
        {
            this._logger = logger;
            _logger.LogInformation($"Created factory activated middleware");
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation($"Started factory activated middleware");
            await next(context);
            _logger.LogInformation($"Ended factory activated middleware");
        }
    }
}
