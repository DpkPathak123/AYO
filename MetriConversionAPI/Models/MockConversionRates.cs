using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MetriConversionAPI.Models
{
    public class MockConversionRates : IConversionRates
    {
        private IConfiguration _configuration;
        public MockConversionRates(IConfiguration config)
        {
            _configuration = config;
        }
        public string GetConverionRates(ConversionDTO objconversion)
        {
            var strconn= _configuration.GetSection("DBConnection").Value;
            SqlConnection conn = new SqlConnection(strconn);
            string result = "";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetConvertedRates", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@unittype", objconversion.UnitType);
                cmd.Parameters.AddWithValue("@unit", objconversion.Unit);
                cmd.Parameters.AddWithValue("@inputvalue", objconversion.Input);
                cmd.Parameters.AddWithValue("@metrictoimperial", (objconversion.IsMteric)?1:0);
                cmd.Parameters.Add("@outputvalues", SqlDbType.Float);
                cmd.Parameters["@outputvalues"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToString(cmd.Parameters["@outputvalues"].Value);

            }
            catch(Exception ex)
            {
                return ex.Message;
            }

            return result;
        }

        public string GetConvertedTemperatures(string InputType, string inputvalue)
        {
            try {
                if (InputType == "Celsius")
                {
                    decimal input = Convert.ToDecimal(inputvalue);
                    input = input * 9 / 5;
                    input = input + 32;
                    return input.ToString();
                }
                else
                {
                    decimal input = Convert.ToDecimal(inputvalue);
                    input = input - 32;
                    input = input * 5/9;
                    return input.ToString();
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
