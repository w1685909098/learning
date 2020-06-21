﻿using ProdService;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Register;

namespace WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private IRegisterService _service;
        public RegisterController(IRegisterService registerService)
        {
            _service = registerService;
        }
        // GET: Register
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(IndexModel model)
        {
            if (_service.GetByName(model.UserName) != null)
            {
                ModelState.AddModelError(nameof(model.UserName), "* 用户名已存在，请重新输入" );
                return View(model);
            }
            IndexModel inviter = _service.GetByName(model.InviterName);
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
            if (!ModelState.IsValid) 
            {
                return View();
            }
            new RegisterService().GetRegisterId(model);
            return View(model);
        }
    }

   
}