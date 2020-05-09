using _17bang.Pages.ViewModel;
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
        public IList<Keyword> Keywords { get; set; }
        public IViewComponentResult Invoke()
        {
            Keywords = new List<Keyword>
            {
                new Keyword{Name="编程开发"},
                new Keyword{Name="C#"},
                new Keyword{Name="JAVA"},
                new Keyword{Name="工具软件"},
                new Keyword{Name="Javascript"},
                new Keyword{Name="顾问咨询"},
                new Keyword{Name="html"},
                new Keyword{Name="VisualStudio"},
                new Keyword{Name="操作系统"},
                new Keyword{Name="SQL"},
                new Keyword{Name="职场"},
                new Keyword{Name="法律"},
                new Keyword{Name="Pyphon"},
                new Keyword{Name=".net"},
                new Keyword{Name="css"},
                new Keyword{Name="Linux"},
            };
            return View(Keywords);
        }
    }
}
