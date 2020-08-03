using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Filter;

namespace WebUI.Controllers
{
    [ContextPerRequest]
    public class BaseController : Controller
    {
        //public int? Id { get; set; }
        public int? currentId
        {
            get
            {
                HttpCookie cookie = HttpContext.Request.Cookies["user"];
                if (cookie == null)
                {
                    return null;
                }
                string id = cookie.Values["id"].ToString();
                return Convert.ToInt32(id);
            }
        }
    }
}