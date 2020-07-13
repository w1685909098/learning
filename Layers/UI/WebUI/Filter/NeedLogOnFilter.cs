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
        }
      
    }
}