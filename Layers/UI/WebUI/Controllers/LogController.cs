using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.LogOn;
using WebUI.Helper;

namespace WebUI.Controllers
{
    public class LogController : Controller
    {
        private ILogOnService _logOn;
        public LogController(ILogOnService logOn)
        {
            _logOn = logOn;
        }
        // GET: Log
        public ActionResult On()
        {
            return View();
        }
        [HttpPost]
        public ActionResult On(LogOnModel model)
        {
            LogOnModel logger = _logOn.GetLogOnModelByName(model.UserName);
            if (logger == null)
            {
                ModelState.AddModelError(nameof(model.UserName), "* 用户名不存在或输入错误，请检查用户名并重新输入");
                return View(model);
            }
            if (logger.Password != model.Password)
            {
                ModelState.AddModelError(nameof(model.Password), "* 密码输入错误，请检查密码并重新输入");
                return View(model);
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            CookieHelper.AddCookie((int)logger.UserId, model.Password);
            return View();
        }
        public ActionResult Off()
        {
            CookieHelper.RemoveCookie();
            return Redirect("/Log/On");
        }
    }
}