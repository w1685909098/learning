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
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

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
            return Redirect("/message/mine");
            //return RedirectToPage("/Message/Mine");
        }
    }
}
