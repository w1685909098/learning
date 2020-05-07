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
        public void OnGet()
        {
            
        }
        public void OnPost()
        { 
            if (!ModelState.IsValid)
            {
                return;
            }
            _userrepository.UserSave(Register);
            Response.Cookies.Append("user", "xx");
        }
    }
}
