using ProdService;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using ViewModel.Register;
using WebUI.Helper;

namespace WebUI.Controllers
{
    public class RegisterController : BaseController
    {
        private IRegisterService _service;
        public RegisterController(IRegisterService registerService)
        {
            _service = registerService;
        }
        // GET: Register
        public ActionResult Index()
        {
            ViewBag.connectionString = ConfigurationManager.ConnectionStrings[0].Name;
            #region Cache理解
            //string userCache = "userId";
            //UserModel CacheModel = HttpContext.Cache.Get(userCache) as UserModel;
            //if (CacheModel == null)
            //{
            //    CacheModel = _service.GetByName("xx");
            //    HttpContext.Cache.Add(userCache, CacheModel,/*cachedenpendency*/null,
            //        DateTime.Now.AddSeconds(20), TimeSpan.Zero, CacheItemPriority.NotRemovable,
            //        (k, v, r) => { Console.WriteLine($"cache with key:{k} and value:{v} is deleted,reason is{r}"); });
            //}//else nothing
            #endregion
            //throw new Exception();
            return View(/*CacheModel*/);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(UserModel model)
        {
     
            if (_service.GetByName(model.UserName) != null)
            {
                ModelState.AddModelError(nameof(model.UserName), "* 用户名已存在，请重新输入");
                return View(model);
            }
            UserModel inviter = _service.GetByName(model.InviterName);
            if (inviter == null)
            {
                ModelState.AddModelError(nameof(model.InviterName), "* 邀请人不存在，请重新输入");
                return View(model);
            }
            if (inviter.InvitingCode != model.InvitingCode)
            {
                ModelState.AddModelError(nameof(model.InvitingCode), "* 邀请人对应的邀请码不正确，请重新输入");
                return View(model);
            }
            if (Session["captcha"].ToString() != model.Captcha)
            {
                ModelState.AddModelError(nameof(model.Captcha), "* 验证码不正确，请重新输入");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _service.GetRegisterId(model);
            CookieHelper.AddCookie((int)model.UserId, model.Password);
            return View(model);
        }
    }


}