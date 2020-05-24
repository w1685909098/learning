using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using _17bang.Pages.Entity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using _17bang.Pages.ViewModel;
using _17bang.Pages.Repository;

namespace _17bang.Pages
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        public UserModel Register { get; set; }
        private UserRepository _userrepository;
        public RegisterModel()
        {
            _userrepository = new UserRepository();
        }
        public ActionResult OnGet()
        {
            return Page();
        }
        public ActionResult OnPost()
        { 
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _userrepository.UserSave(Register);
            Response.Cookies.Append("user", "xx");
            //return Redirect(Request.Headers["Referer"]);

            return Redirect(Request.Query["prepage"]);
            //string prepage = HttpContext.Request.Query["prepage"];
            //if (string.IsNullOrEmpty(prepage))
            //{
            //    prepage = HttpContext.Request.Path + HttpContext.Request.QueryString;
            //}
            //return Redirect(Request.Query[prepage]);
        }
    }
}
