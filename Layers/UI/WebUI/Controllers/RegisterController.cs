using ProdService;
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
        private IRegisterService _registerService;
        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }
        // GET: Register
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(IndexModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View();
            }
            new RegisterService().GetRegisterId(model);
            return View(model);
        }
    }

   
}