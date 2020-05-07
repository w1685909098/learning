using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace _17bang.Pages
{
    public class IndexModel : PageModel
    {
        public ActionResult OnGet()
        {
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
