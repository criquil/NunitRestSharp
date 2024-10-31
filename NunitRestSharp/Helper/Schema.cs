using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitRestSharp.Helper
{
    internal class Schema
    {
        public static JSchema ReadSchema(string path)
        {
            JSchema schema = JSchema.Parse(File.ReadAllText(path));
        
            return schema;
        }
        public static void isValidSchema(string path, RestResponse response) 
        {
            
            var jSchema = ReadSchema(path);
            JToken jToken = JToken.Parse(response.Content);
            bool validSchema = jToken.IsValid(jSchema);
            Assert.True(validSchema);
        }
    }
}
