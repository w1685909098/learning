using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            _emailService.ValidEmail("1685909098@qq.com");
            return View();
        }
        [HttpPost]
        public ActionResult Activate(int id,string code)
        {

            return View();
        }
    }
}