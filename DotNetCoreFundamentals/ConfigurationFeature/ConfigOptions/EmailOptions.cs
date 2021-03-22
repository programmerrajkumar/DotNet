using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationFeature.ConfigOptions
{
    public class EmailOptions
    {
        public const string Email = "Email";

        [EmailAddress]
        public string AdminAddress { get; set; }
        public SmtpOptions Smtp { get; set; }

        //Validation is not getting fired for nested class
        public class SmtpOptions
        {
            public string ServerAddress { get; set; }
            [Range(0, 1)]
            public int Port { get; set; }
            [EmailAddress]
            public string SenderAddress { get; set; }
        }
    }
}
