using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Filter
{
    public class NeedLogOnFilter :AuthorizeAttribute/*,IAuthorizationFilter,IActionFilter,IResultFilter,IExceptionFilter*/
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            HttpCookie cookie = filterContext.RequestContext.HttpContext.Request.Cookies["user"];
            if (cookie==null)
            {
                filterContext.Result = new RedirectResult("/Log/On"); //重定向问题
            }
        }
      
    }
}