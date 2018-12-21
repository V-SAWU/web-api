using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OauthModal
{
    public class ReturnObject
    {
        public int Result { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public long Total { get; set; }
    }
}
