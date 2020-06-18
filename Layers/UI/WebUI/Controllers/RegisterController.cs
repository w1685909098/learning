using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            UserRepository userRepository = new UserRepository();
            if (userRepository.GetUserByName(model.UserName)==null)
            {

            }
            User register = new User 
            { 
                UserName=model.UserName,
                Password=model.Password
            };
            User inviter = userRepository.GetUserByName(model.Inviter.UserName);
            register.Register(register, inviter);
            userRepository.Add(register);
            return View();
        }
    }

    public class IndexModel
    {
        public User Inviter { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}