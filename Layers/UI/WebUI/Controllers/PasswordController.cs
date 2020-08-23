using Extension;
using ProdService;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Password;
using WebUI.Helper;

namespace WebUI.Controllers
{
    public class PasswordController : BaseController
    {
        private IPasswordService _passwordService;
        public PasswordController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }
        // GET: Password
       
        public ActionResult Change()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Change(ChangeModel model)//映射太少  破坏数据库的完整性
        {
            ChangeModel RepoModel = _passwordService.GetChangeModelById((int)currentId);
            if (model.PresentPassword.MD5Encrypt()!=RepoModel.PresentPassword)
            {
                ModelState.AddModelError(nameof(model.PresentPassword), "* 密码不正确，请检查密码并重新输入");
                return View(model);
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            RepoModel.UpdatePassword = model.UpdatePassword.MD5Encrypt();
            _passwordService.UISaveChangeModel(RepoModel);//更改密码出现问题cookie里面的密码与更改的密码发生冲突，试试出现添加cookie
            CookieHelper.RemoveCookie();
            CookieHelper.AddCookie((int)RepoModel.Id, model.UpdatePassword);
            return View();
        }

        public ActionResult Forget()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Forget(ForgetModel model)
        {
            //new EmailService().SendEmailHeiper(model.EmailAddress);//真
            new EmailService().SendEmailHelper("1685909098@qq.com");//假的 开发便利
            ForgetModel RepoModel = _passwordService.GetForgetModelByName(model.UserName);
            if (RepoModel!=null)
            {
                return View(RepoModel);
            }
            if (model.VerificationCode!=Session["Captcha"].ToString())
            {
                ModelState.AddModelError(nameof(model.VerificationCode), "* 验证码不正确");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            return View(model);
        }

        public ActionResult Reset()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Reset(ResetModel model)
        {
            ResetModel RepoModel = _passwordService.GetResteModel();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            RepoModel.UpdatePassword = model.UpdatePassword.MD5Encrypt();
            _passwordService.UISaveResetModel(RepoModel);
            CookieHelper.RemoveCookie();
            CookieHelper.AddCookie((int)RepoModel.Id, model.UpdatePassword);
            return View();
        }
    }
}