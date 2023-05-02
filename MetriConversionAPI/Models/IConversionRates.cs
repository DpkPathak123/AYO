using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetriConversionAPI.Models
{
    public interface IConversionRates
    {
        string GetConverionRates(ConversionDTO objconversion);
        string GetConvertedTemperatures(string InputType, string inputvalue);
    }
}
