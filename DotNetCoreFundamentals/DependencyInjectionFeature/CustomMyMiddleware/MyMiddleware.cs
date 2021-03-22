using DependencyInjectionFeature.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionFeature.CustomMyMiddleware
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;
        private readonly ISingletonService _singletonService;

        public MyMiddleware(RequestDelegate next, ILogger<MyMiddleware> logger,
            ITransientService transientService1,
            ITransientService transientService2,
            ISingletonService singletonService)
        {
            _logger = logger;
            _transientService1 = transientService1;
            _transientService2 = transientService2;
            _singletonService = singletonService;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,
            IScopedService scopedOperation, IEnumerable<ISingletonService> singletonServices)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Accessed:\t{_transientService1.OperationId}");
            sb.AppendLine($"Accessed:\t{_transientService2.OperationId}");
            sb.AppendLine($"Accessed:\t{scopedOperation.OperationId}");
            sb.AppendLine($"Accessed:\t{_singletonService.OperationId}");
            sb.Append($"Accessed:\t There are {singletonServices.Count()} instance of {nameof(ISingletonService)}");

            _logger.LogInformation(sb.ToString());

            await _next(context);
        }
    }

    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            ExemplifyScoping(builder.ApplicationServices, "scope-1");
            ExemplifyScoping(builder.ApplicationServices, "scope-2");

            return builder.UseMiddleware<MyMiddleware>();
        }

        static void ExemplifyScoping(IServiceProvider services, string scope)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            var logger = provider.GetRequiredService<ILogger<string>>();
            var service = provider.GetRequiredService<IScopedService>();
            logger.LogInformation($"{scope}-Call 1 {service.OperationId}");

            service = provider.GetRequiredService<IScopedService>();
            logger.LogInformation($"{scope}-Call 2 {service.OperationId}");


            var transientService = provider.GetRequiredService<ITransientService>();
            logger.LogInformation($"{scope}-Call 1 {transientService.OperationId}");
            
            transientService = provider.GetRequiredService<ITransientService>();
            logger.LogInformation($"{scope}-Call 2 {transientService.OperationId}");
        }
    }
}
