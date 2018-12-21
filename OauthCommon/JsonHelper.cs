using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OauthCommon
{
    public class JsonHelper
    {
        public static string SerializeObject<T>(T t)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(t);
        }

        public static T DeserializeObject<T>(string jsonString)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
