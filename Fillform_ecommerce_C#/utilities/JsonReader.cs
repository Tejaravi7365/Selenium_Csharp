using Newtonsoft.Json.Linq;
using OpenQA.Selenium.DevTools.V120.Audits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fillform_ecommerce_C.utilities
{
    public class JsonReader
    {
        public JsonReader() 
        { 
        
        }
        public string ReadsData(String tokenName)
        {
            String jsonString = File.ReadAllText("C:\\Users\\ravit\\source\\repos\\Csharptraining\\Fillform_ecommerce_C#\\utilities\\testdata.json");

            var jsonObject = JToken.Parse(jsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();

        }
    }

   
}
