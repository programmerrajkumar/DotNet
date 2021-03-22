using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationFeature.ConfigOptions
{
    public class CarOptions
    {
        public const string CyberTruck = "CyberTruck";
        public const string Tesla = "Tesla";
        public const string TeslaPath = "Car:Tesla";
        public const string CyberTruckPath = "Car:CyberTruck";

        [Range(1886, 3000)]
        public int MakeYear { get; set; }
        public string EnergySource { get; set; }
    }
}
