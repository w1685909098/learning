using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            //return View();
            #region cookie理解
            //HttpCookie cookie = new HttpCookie("user");
            //cookie.Values.Add("Id", "11");
            //cookie.Values.Add("Password", "1234");
            //cookie.Expires = DateTime.Now.AddDays(14);
            //cookie.Values.Clear();
            //Response.Cookies.Add(cookie);
            #endregion

            //return Redirect("/Register");
            //return Redirect("/Article");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}