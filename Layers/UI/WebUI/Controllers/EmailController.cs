﻿using ServiceInterface;
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
        public ActionResult Activate()
        {
            //_emailService.ValidEmail("1685909098@qq.com");
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
        public ActionResult Activate(int id, string code)
        {
            bool success = _emailService.BindEmail(id, code);
            if (success==false)
            {
                return View();
            }  //else保存至数据库
            return View();
        }
    }
}