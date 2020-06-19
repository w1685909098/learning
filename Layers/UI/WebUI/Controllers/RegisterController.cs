using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

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
        [Required]
        public User Inviter { get; set; }
        [Required]
        public string UserName { get; set; }
        [MaxLength(18,ErrorMessage ="* 密码最大长度不能超过18")]
        public string Password { get; set; }
        [Compare(nameof(Password),ErrorMessage ="* 两次输入密码不一致")]
        public string ComfirmPassword { get; set; }
    }
}