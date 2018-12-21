using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OauthModal
{
    public class PromptMessage
    {
        public enum ErrorCode
        {
            Err_Fail = -100,                     //失败
            Err_Success = 100,                   //成功
            Err_Empty = 1000,                    //参数不可空
            Err_Token = 2000                     //验证失败
        }

        public static string ErrorMessage(int errCode)
        {
            switch (errCode)
            {
                case (int)ErrorCode.Err_Fail: return "false";
                case (int)ErrorCode.Err_Success: return "success";
                case (int)ErrorCode.Err_Empty: return "Parameter cannot be empty";
                case (int)ErrorCode.Err_Token: return "Validation fails";
                default: return "Unknown error";
            }
        }
    }
}
