﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Pages.Entity;
using _17bang.Pages.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace _17bang.Pages
{
    public class IndexModel : PageModel
    {
        public IList<UserPageModel>  models { get; set; }
        public ActionResult OnGet()
        {
            UserPageModel CSharp = new UserPageModel { Name="C#"};
            UserPageModel SQL = new UserPageModel { Name = "sql" };
            UserPageModel Javasript = new UserPageModel { Name = "java" };
            UserPageModel PHP = new UserPageModel { Name = "php" };
            models=new List<UserPageModel> { CSharp,SQL,Javasript,PHP};
            //return RedirectToPagePermanent("/*Pages/Message/Mine*/");
            return Page();

        }
        public ActionResult OnPost()
        {
            Response.Cookies.Append("tt", "23");
            Response.Cookies.Append("xx", "25",
                new Microsoft.AspNetCore.Http.CookieOptions
                {/*Domain=".localhost",*/
                    //Path = "/Pages/Message",
                    Expires = DateTime.Now.AddDays(7)
                }
                );
            Response.Cookies.Delete("tt");
            return RedirectToPagePermanent("/Log/On");
            //return RedirectToPage("LogOn");
        }
    }
}
