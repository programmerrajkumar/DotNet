using DependencyInjectionFeature.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MyServicesExtension
    {
        public static IServiceCollection AddMyServices(this IServiceCollection services)
        {
            services.AddTransient<ITransientService, MyUniqueIdContext>();
            services.AddScoped<IScopedService, MyRequestContext>();
            services.AddSingleton<ISingletonService, MyApplicationContext>();
            services.AddSingleton<ISingletonService, MyCacheContext>();
            services.TryAddSingleton<ISingletonService, MyCacheContext>();

            // services.AddTransient<ITransientService>(x => new MyUniqueIdContext(x.GetRequiredService<ILogger<MyUniqueIdContext>>(), "Transient"));


            return services;
        }
    }
}
