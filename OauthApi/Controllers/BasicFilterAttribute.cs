using OauthCommon;
using OauthModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using static OauthModal.PromptMessage;

namespace OauthApi.Controllers
{
    public class BasicFilterAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        { 
            var authorization = actionContext.Request.Headers.Authorization;
            if ((authorization != null) && (authorization.Parameter != null))
            {
                var encryptTicket = authorization.Parameter;
                if (encryptTicket.Equals("1234567890"))            
                {
                    base.IsAuthorized(actionContext);
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
            else
            {
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if (isAnonymous) base.OnAuthorization(actionContext);
                else HandleUnauthorizedRequest(actionContext);
            }
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            ReturnObject rObj = new ReturnObject();
            rObj.Result = (int)ErrorCode.Err_Token;
            rObj.Message = PromptMessage.ErrorMessage((int)ErrorCode.Err_Token); 
            actionContext.Response = HttpCommon.Content(JsonHelper.SerializeObject<object>(rObj));
        }
    }
}