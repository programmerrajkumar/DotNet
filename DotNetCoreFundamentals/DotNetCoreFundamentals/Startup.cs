using DotNetCoreFundamentals.CustomStartupFilter;
using DotNetCoreFundamentals.EndPointMetadata;
using DotNetCoreFundamentals.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace DotNetCoreFundamentals
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IStartupFilter, StartupFilter1>();
            services.AddTransient<IStartupFilter, StartupFilter2>();
            services.AddHostedService<LifetimeEventsHostedService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Location 1: before routing runs, endpoint is always null here
            app.Use(next => context =>
            {
                Console.WriteLine($"1. Endpoint: {context.GetEndpoint()?.DisplayName ?? "(null)"}");
                return next(context);
            });

            //When a routing middleware executes, it sets an Endpoint and route values to a request feature on the HttpContext 

            app.UseRouting();

            // Location 2: after routing runs, endpoint will be non-null if routing found a match
            app.Use(next => context =>
            {
                var endpoint = context.GetEndpoint();
                if (endpoint is null)
                {
                    return Task.CompletedTask;
                }

                Console.WriteLine($"Endpoint: {endpoint.DisplayName}");

                if (endpoint is RouteEndpoint routeEndpoint)
                {
                    Console.WriteLine("Endpoint has route pattern: " +
                        routeEndpoint.RoutePattern.RawText);
                }

                foreach (var metadata in endpoint.Metadata)
                {
                    Console.WriteLine($"Endpoint has metadata: {metadata}");
                }

                if (endpoint?.Metadata.GetMetadata<AuditPolicyAttribute>()?.NeedsAudit
                                                                            == true)
                {
                    Console.WriteLine($"ACCESS TO SENSITIVE DATA AT: {DateTime.UtcNow}");
                }

                return next(context);
            });

            // Endpoint aware middleware. 
            // Middleware can use metadata from the matched endpoint.
            //app.UseAuthentication();
            //app.UseAuthorization();

            app.Use(next => async context =>
            {
                if (context.Request.Path == "/middlewareroute") // middleware can also do  matching operation like endpoints.Map("/")
                {
                    await context.Response.WriteAsync("Hello terminal middleware!");
                    return;
                }

                await next(context);
            });

            app.UseEndpoints(endpoints =>
            {
                // Location 3: runs when this endpoint matches
                endpoints.MapGet("/", async context =>
                {
                    Console.WriteLine($"3. Endpoint: {context.GetEndpoint()?.DisplayName ?? "(null)"}");
                    await context.Response.WriteAsync("Hello World!");
                   // return Task.CompletedTask;

                })
                .WithDisplayName("Hello")
                .WithMetadata(new AuditPolicyAttribute(true));//adds config for each endpoint
            });

            // Location 4: runs after UseEndpoints - will only run if there was no match
            app.Use(next => context =>
            {
                Console.WriteLine($"4. Endpoint: {context.GetEndpoint()?.DisplayName ?? "(null)"}");
                return next(context);
            });
        }

    }
}
