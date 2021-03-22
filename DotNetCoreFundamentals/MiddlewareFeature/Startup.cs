using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MiddlewareFeature.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareFeature
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<FactoryActivatedMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAdditionSecurity();

            app.UseFactoryActivatedMiddleware();

            app.Use(async (context, next) =>
            {
                // Do work that doesn't write to the Response.
                logger.LogInformation("Started Middleware 1");
                await next.Invoke();
                // Do logging or other work that doesn't write to the Response.
                logger.LogInformation("Ended Middleware 1");
            });

            app.Use(async (context, next) =>
            {
                // Do work that doesn't write to the Response.
                logger.LogInformation("Started Middleware 2");
                await next.Invoke();
                // Do logging or other work that doesn't write to the Response.
                logger.LogInformation("Ended Middleware 2");
            });

            app.UseRouting();

            app.Map("/level1", level1App =>
            {
                level1App.Map("/level2a", level2AApp =>
                {
                    // "/level1/level2a" processing
                });
                level1App.Map("/level2b", level2BApp =>
                {
                    // "/level1/level2b" processing
                });
            });

            app.UseEndpoints(endpoints =>
            {
                // MapGet - HTTPGet
                //"/"-domain name only
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                //Map - all HTTP request
                endpoints.Map("/All", async context =>
                {

                    await context.Response.WriteAsync("\nHello World! I will support all kind of HTTP request");
                    //await Task.Delay(2000);
                    // throw new Exception("i'm inevitable");

                });


            });
        }
    }
}
