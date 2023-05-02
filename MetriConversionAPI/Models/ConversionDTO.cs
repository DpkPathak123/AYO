
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetriConversionAPI.Models
{
    public class ConversionDTO
    {
        public string UnitType { get; set; }
        public string Unit { get; set; }
        public decimal Input { get; set; }
        public bool IsMteric { get; set; }
    }
}
