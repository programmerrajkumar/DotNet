using ConfigurationFeature.ConfigOptions;
using ConfigurationFeature.ConfigOptions.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceGroups
    {
        public static void AddMyAppConfigOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<EmailOptions>().Bind(configuration.GetSection(EmailOptions.Email)).ValidateDataAnnotations();


            services.Configure<CarOptions>(CarOptions.CyberTruck, configuration.GetSection(CarOptions.CyberTruckPath));
            services.Configure<CarOptions>(CarOptions.Tesla, configuration.GetSection(CarOptions.TeslaPath));

            services.Configure<VendorDetailOptions>(configuration.GetSection(VendorDetailOptions.VendorDetail));
            services.AddSingleton<IValidateOptions<VendorDetailOptions>, VendorDetailOptionsValidation>();

            //services.AddOptions<CarOptions>().Bind(configuration.GetSection(CarOptions.CyberTruckPath)).ValidateDataAnnotations();
            //services.AddOptions<CarOptions>().Bind(configuration.GetSection(CarOptions.TeslaPath)).ValidateDataAnnotations();

            services.PostConfigure<EmailOptions>(option =>
            {


            });
        }
    }
}
