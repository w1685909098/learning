using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.Shared.Components._Keywords
{
    public class _Keywords:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
