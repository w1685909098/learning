using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Register;

namespace WebUI.Controllers
{
    public class EmailController : BaseController
    {
        private IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        // GET: Email
        public ActionResult Activate( )
        {
            UserModel currentModel = _emailService.GetUserModelById((int)currentId);
            _emailService.SendEmail(currentModel);
            return View();
        }
        //[HttpPost]
        //public ActionResult Activate(UserModel model)
        //{
        //    UserModel user = _emailService.GetUserModelByName(model.UserName);
        //    if (model.EmailCode != user.EmailCode)
        //    {
        //        ModelState.AddModelError(nameof(model.EmailCode), "* 验证码不正确，请检查并重新输入");
        //        return View(model);
        //    }
        //    if (DateTime.Now > user.ExprieTime)
        //    {
        //        ModelState.AddModelError(nameof(model.ExprieTime), "* 验证码超过有效期，请重新发送验证码");
        //        return View(model);
        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    return View();
        //}

        [HttpPost]
        public ActionResult Activate(UserModel model )
        {
            UserModel currentModel = _emailService.GetUserModelById((int)currentId);
            currentModel.EmailAddress = model.EmailAddress;
            currentModel.EmailCode = model.EmailCode;
            bool success = _emailService.BindEmail((int)currentModel.UserId, currentModel.EmailCode);
            if (success==false)
            {
                return View(model);
            }
            else
            {
                currentModel.EmailIsActivate = true;
                _emailService.UIMapUserSaveChanges(currentModel);
            }
            return View(model);
        }
    }
}