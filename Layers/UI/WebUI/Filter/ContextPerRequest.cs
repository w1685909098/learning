using ProdService;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Filter
{
    public class ContextPerRequest:ActionFilterAttribute
    {
        public IBaseService BaseService { get; set; }  //属性进行依赖注入
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if (! filterContext.IsChildAction)
            {
                if (filterContext.Exception==null)
                {
                    BaseService.CommitTrans();
                }
                else
                {
                    BaseService.RollbackTrans();
                }
            }
        }
    }
}