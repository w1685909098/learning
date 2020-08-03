using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class EmailController : BaseController
    {
        // GET: Email
        public ActionResult Activate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Activate(string address,string code)
        {
            return View();
        }
    }
}