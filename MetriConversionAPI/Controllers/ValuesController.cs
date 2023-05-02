using Microsoft.AspNetCore.Mvc;
using MetriConversionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetriConversionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IConversionRates _conversionrates;
        public ValuesController(IConversionRates conversionrates)
        {
            _conversionrates = conversionrates;
        }
        [HttpGet]
        [Route("Convertcentimetertoinch")]
        public ActionResult<string> Convertcentimetertoinch(string value)
        {
            ConversionDTO objdata = new ConversionDTO();
            objdata.UnitType = "Length";
            objdata.Unit = "cm-in";
            objdata.IsMteric = true;
            objdata.Input = Convert.ToDecimal(value);
            return _conversionrates.GetConverionRates(objdata);
        }
        [HttpGet]
        [Route("Convertinchtocentimeter")]
        public ActionResult<string> Convertinchtocentimeter(string value)
        {
            ConversionDTO objdata = new ConversionDTO();
            objdata.UnitType = "Length";
            objdata.Unit = "cm-in";
            objdata.IsMteric = false;
            objdata.Input = Convert.ToDecimal(value);
            return _conversionrates.GetConverionRates(objdata);
        }
        [HttpGet]
        [Route("Convertmetertoyard")]
        public ActionResult<string> Convertmetertoyard(string value)
        {
            ConversionDTO objdata = new ConversionDTO();
            objdata.UnitType = "Length";
            objdata.Unit = "m-yd";
            objdata.IsMteric = true;
            objdata.Input = Convert.ToDecimal(value);
            return _conversionrates.GetConverionRates(objdata);
        }
        [HttpGet]
        [Route("Convertyardtometer")]
        public ActionResult<string> Convertyardtometer(string value)
        {
            ConversionDTO objdata = new ConversionDTO();
            objdata.UnitType = "Length";
            objdata.Unit = "m-yd";
            objdata.IsMteric = false;
            objdata.Input = Convert.ToDecimal(value);
            return _conversionrates.GetConverionRates(objdata);
        }
        [HttpGet]
        [Route("Convertkmtomile")]
        public ActionResult<string> Convertkmtomile(string value)
        {
            ConversionDTO objdata = new ConversionDTO();
            objdata.UnitType = "Length";
            objdata.Unit = "km-mi";
            objdata.IsMteric = true;
            objdata.Input = Convert.ToDecimal(value);
            return _conversionrates.GetConverionRates(objdata);
        }
        [HttpGet]
        [Route("Convertmiletokm")]
        public ActionResult<string> Convertmiletokm(string value)
        {
            ConversionDTO objdata = new ConversionDTO();
            objdata.UnitType = "Length";
            objdata.Unit = "km-mi";
            objdata.IsMteric = false;
            objdata.Input = Convert.ToDecimal(value);
            return _conversionrates.GetConverionRates(objdata);
        }
        [HttpGet]
        [Route("Convertkgtolb")]
        public ActionResult<string> Convertkgtolb(string value)
        {
            ConversionDTO objdata = new ConversionDTO();
            objdata.UnitType = "Mass";
            objdata.Unit = "kg-lb";
            objdata.IsMteric = true;
            objdata.Input = Convert.ToDecimal(value);
            return _conversionrates.GetConverionRates(objdata);
        }
        [HttpGet]
        [Route("Convertlbtokg")]
        public ActionResult<string> Convertlbtokg(string value)
        {
            ConversionDTO objdata = new ConversionDTO();
            objdata.UnitType = "Mass";
            objdata.Unit = "kg-lb";
            objdata.IsMteric = false;
            objdata.Input = Convert.ToDecimal(value);
            return _conversionrates.GetConverionRates(objdata);
        }
        [HttpGet]
        [Route("ConvertCeltoFaren")]
        public ActionResult<string> ConvertCeltoFaren(string value)
        {
            return _conversionrates.GetConvertedTemperatures("Celsius", value);
        }
        [HttpGet]
        [Route("ConvertFarentocel")]
        public ActionResult<string> ConvertFarentocel(string value)
        {
            return _conversionrates.GetConvertedTemperatures("Farenhiet", value);
        }
    }
}
