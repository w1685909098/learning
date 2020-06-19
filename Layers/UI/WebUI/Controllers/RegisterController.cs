using ProdService;
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
            RegisterService service = new RegisterService();
            service.Register(model);
            return View();
        }
    }

   
}