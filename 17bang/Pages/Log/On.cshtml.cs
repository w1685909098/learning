using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
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
        public PageResult OnGet()
        {

            ViewData["UserName"] = HttpContext.Request.Cookies["UserName"];
            if (ViewData["UserName"] == null)
            {
                ViewData["UserName"] = "未登录";
            }
            else
            {
                ViewData["UserName"] = HttpContext.Request.Cookies["UserName"];
            }
            //ViewData["UserName"] = HttpContext.Session.GetString("UserName");

            //if (ViewData["UserName"] == null)
            //{
            //    ViewData["UserName"] = "未登录";
            //}
            //else
            //{
            //    ViewData["UserName"] = HttpContext.Session.GetString("UserName");
            //}
            //ViewData["name"] = HttpContext.Session.GetString("name");
            return Page();
            //string prepage = HttpContext.Request.Query["prepage"];
            //if (string.IsNullOrEmpty(prepage))
            //{
            //    prepage = HttpContext.Request.Path + HttpContext.Request.QueryString;
            //}
            //return Redirect(Request.Query[prepage]);
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
            //Response.Cookies.Append("zz", "zz",
            //    new Microsoft.AspNetCore.Http.CookieOptions {Expires=DateTime.Now.AddDays(14) });
            //HttpContext.Session.SetString("name", "Id");
            //Response.Cookies.Append("UserName", LogOnModel.Name,
            //    new CookieOptions { Expires = DateTime.Now.AddDays(14) }
            //    );
            Response.Cookies.Append("UserName", LogOnModel.Name);
            HttpContext.Session.SetString("UserName", LogOnModel.Name);
            return Redirect(Request.Query["prepage"]);
            //return Redirect(Request.Headers["Referer"]);
            //string prepage = HttpContext.Request.Query["prepage"];
            //if (string.IsNullOrEmpty(prepage))
            //{
            //    prepage = HttpContext.Request.Path + HttpContext.Request.QueryString;
            //}
            //return Redirect(Request.Query[prepage]);
        }
    }
}