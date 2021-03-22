using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationFeature.ConfigOptions.Validation
{
    public class VendorDetailOptionsValidation : IValidateOptions<VendorDetailOptions>
    {
        public ValidateOptionsResult Validate(string name, VendorDetailOptions options)
        {
            if (options.Url.StartsWith("https:"))
                return ValidateOptionsResult.Success;

            return ValidateOptionsResult.Fail("only secure service is allowed.");
        }
    }
}
