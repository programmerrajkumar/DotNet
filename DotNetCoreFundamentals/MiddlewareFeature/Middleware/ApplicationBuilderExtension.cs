using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareFeature.Middleware
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseAdditionSecurity(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<AdditionalSecurityMiddleware>();
            return builder;
        }

        public static IApplicationBuilder UseFactoryActivatedMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<FactoryActivatedMiddleware>();
            return builder;
        }
    }
}
