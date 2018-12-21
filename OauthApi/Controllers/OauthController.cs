using OauthCommon;
using OauthModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static OauthModal.PromptMessage;

namespace OauthApi.Controllers
{
    public class OauthController : ApiController
    {
        [HttpPost]
        [Route("api/GetToken")]
        public HttpResponseMessage GetToken(User user)
        {
            var json = string.Empty;
            try
            {
                ReturnObject rObj = new ReturnObject();
                if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Name))
                {
                    rObj.Result = (int)ErrorCode.Err_Empty;
                    rObj.Message = PromptMessage.ErrorMessage((int)ErrorCode.Err_Empty);
                    json = JsonHelper.SerializeObject<ReturnObject>(rObj);
                    return HttpCommon.Content(json);
                }

                rObj.Result = (int)ErrorCode.Err_Success;
                rObj.Message = PromptMessage.ErrorMessage((int)ErrorCode.Err_Success);
                rObj.Total = 1;
                rObj.Data = 1234567890;
                json = JsonHelper.SerializeObject<ReturnObject>(rObj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return HttpCommon.Content(json);
        }

             
        [HttpGet]
        [BasicFilter]
        [Route("api/GetUserList")]
        public HttpResponseMessage GetUserList()
        {
            var json = string.Empty;
            try
            {
                List<User> userList = new List<OauthModal.User>();
                userList.Add(new OauthModal.User { ID = 1, Name = "sam1", Password = "123456" });
                userList.Add(new OauthModal.User { ID = 2, Name = "sam2" ,Password="1234567"});
                userList.Add(new OauthModal.User { ID=3,Name="sam3",Password="12345678"});

                ReturnObject rObj = new ReturnObject();
                rObj.Result = (int)ErrorCode.Err_Success;
                rObj.Message = PromptMessage.ErrorMessage((int)ErrorCode.Err_Success);
                rObj.Total = userList.Count;
                rObj.Data = userList;
                json = JsonHelper.SerializeObject<ReturnObject>(rObj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return HttpCommon.Content(json);
        }
    }
}
