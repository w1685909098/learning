using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.Filter
{
    public class NeedLogOnAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //throw new NotImplementedException();
            string CurrentUser = context.HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(CurrentUser))
            {
                context.Result = new RedirectToPageResult("/Log/On");
            }
        }
    }
}
