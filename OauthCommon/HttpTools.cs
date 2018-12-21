using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OauthCommon
{
    public class HttpTools
    {
        public static string HttpGet(string reqUrl)
        {
            using (var client = new WebClient())
            {
                client.Encoding = System.Text.Encoding.UTF8;
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                client.Headers.Add("Authorization", string.Format("Basic {0}", ReadHelper.Token));
                return client.DownloadString(reqUrl);
            }
        }

        public static string HttpPost(string postUrl, object msgData)
        {
            byte[] postData = null;
            if (DBNull.Value != msgData)
            {
                var parastr = JsonHelper.SerializeObject(msgData);
                postData = Encoding.UTF8.GetBytes(parastr);
            }
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");
                client.Headers.Add("Authorization", string.Format("Basic {0}", ReadHelper.Token));
                byte[] responseData = client.UploadData(postUrl, "POST", postData); 
                return Encoding.UTF8.GetString(responseData);
            }
        } 
    }
}
