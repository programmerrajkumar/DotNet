using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationFeature.ConfigOptions
{
    public class VendorDetailOptions
    {
        public const string VendorDetail = "VendorDetail";
        public const string VendorDetailPath = "VendorDetail";
        public string Name { get; set; }
        public string Url { get; set; }
        public string EmailAddress { get; set; }
    }
}
