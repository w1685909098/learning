using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using _17bang.Pages.Entity;
using _17bang.Pages.Repository;
using _17bang.Pages.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;

namespace _17bang.Pages.Log
{
    [BindProperties]
    public class OnModel : PageModel
    {
        private UserRepository _userRepository;
        public OnModel()
        {
            _userRepository = new UserRepository();
        }
        public LogOnModel LogOnModel { get; set; }
        public bool RememberMe { get; set; }
        public ActionResult OnGet()
        {
            ViewData["name"] = HttpContext.Session.GetString("name");
            return Page();
        }
        public ActionResult OnPost()
        {
            UserModel user = _userRepository.GetUserByName(LogOnModel.Name);
            if (user==null)
            {
                ModelState.AddModelError("LogOnModel.Name", "* 用户名不存在");
                return Page();
            }
            if (user.Password !=LogOnModel.Password)
            {
                ModelState.AddModelError("LogOnModel.Password", "* 用户名或密码输入错误");
                return Page();
            }
            Response.Cookies.Append("zz", "zz",
                new Microsoft.AspNetCore.Http.CookieOptions {Expires=DateTime.Now.AddDays(14) });
            HttpContext.Session.SetString("name", "Id");

            return Page();
        }
    }
}