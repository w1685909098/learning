using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace _17bang.Pages.Shared.Components._Keywords
{
    public class _Keywords:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            IList<string> keywords = new List<string> { "25","23","26","35","48" };
            return View(keywords);
        }
    }
}
