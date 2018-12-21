using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OauthCommon
{
    public class HttpCommon
    {     
        public static HttpResponseMessage Content(string json)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json");
            return response;
        }

    }
}
