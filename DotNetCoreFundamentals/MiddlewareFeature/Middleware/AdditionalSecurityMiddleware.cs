using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareFeature.Middleware
{
    public class AdditionalSecurityMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AdditionalSecurityMiddleware> _logger;

        public AdditionalSecurityMiddleware(RequestDelegate next, ILogger<AdditionalSecurityMiddleware> logger)
        {
            _next = next;
            this._logger = logger;
            _logger.LogInformation($"Created conventional middleware");
        }

        public async Task InvokeAsync(HttpContext context)//,IScopedService service) can be injected
        {
            _logger.LogInformation($"Started conventional middleware");

            var token = context.Request.Query["specialtoken"];

            if (string.IsNullOrEmpty(token))
                await context.Response.WriteAsync("Invalid Request.Specail token missing");

            await _next(context);
            _logger.LogInformation($"Ended conventional middleware");

        }
    }
}
