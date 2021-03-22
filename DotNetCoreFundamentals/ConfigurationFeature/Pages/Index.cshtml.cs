using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurationFeature.ConfigOptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ConfigurationFeature.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfigurationRoot _configurationRoot;
        private readonly IOptions<EmailOptions> _emailOptions;
        private readonly CarOptions _teslaOptionsSnapshot;
        private readonly CarOptions _cybertruckOptionsSnapshot;
        private readonly IOptionsMonitor<EmailOptions> _emailOptionsMonitor;
        private readonly IOptions<VendorDetailOptions> _vendorDetailOptions;

        public IndexModel(IConfiguration configuration,
                          IOptions<EmailOptions> emailOptions,
                          IOptionsSnapshot<CarOptions> carOptionsSnapshot,
                          IOptionsMonitor<EmailOptions> emailOptionsMonitor,
                          IOptions<VendorDetailOptions> vendorDetailOptions
                          )
        {
            _configurationRoot = configuration as IConfigurationRoot;

            _emailOptions = emailOptions;
            _emailOptionsMonitor = emailOptionsMonitor;

            _teslaOptionsSnapshot = carOptionsSnapshot.Get(CarOptions.Tesla);
            _cybertruckOptionsSnapshot = carOptionsSnapshot.Get(CarOptions.CyberTruck);
            _vendorDetailOptions = vendorDetailOptions;
        }
        public ContentResult OnGet()
        {
            var contentResult = string.Empty;

            foreach (var provider in _configurationRoot.Providers.ToList())
            {
                contentResult += provider.ToString() + "\n";
            }


            try
            {
                var emailOptions = new EmailOptions();
                _configurationRoot.GetSection(EmailOptions.Email).Bind(emailOptions);
                emailOptions = _configurationRoot.GetSection(EmailOptions.Email).Get<EmailOptions>();

                if (_emailOptions.Value?.Smtp.ServerAddress == emailOptions?.Smtp.ServerAddress)
                {
                    contentResult += "\nValue from Config:" + _emailOptions.Value.Smtp.ServerAddress + "\n";
                    contentResult += "\nValue from Config:" + _emailOptions.Value.Smtp.SenderAddress + "\n";
                }
            }
            catch (OptionsValidationException ex)
            {
                contentResult += "\n config validation:" + ex.Message + "\n";
            }
            try
            {
                var temp = _vendorDetailOptions.Value.EmailAddress;
            }
            catch (OptionsValidationException ex)
            {
                contentResult += "\n config validation:" + ex.Message + "\n";
            }

            return Content(contentResult);
        }
    }
}
