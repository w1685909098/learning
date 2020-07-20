using ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Filter
{
    public class ContextPerRequest:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if (! filterContext.IsChildAction)
            {
                if (filterContext.Exception==null)
                {
                    new BaseService().CommitTrans();
                }
                else
                {
                    new BaseService().RollbackTrans();
                }
            }
        }
    }
}