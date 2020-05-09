using _17bang.Pages.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.Shared.Components._Advertisements
{
    public class _Advertisements : ViewComponent
    {
        public IList<Advertisements> Advertisements { get; set; }
        public IViewComponentResult Invoke()
        {
            Advertisements = new List<Advertisements>
            {
                new Advertisements{Title="学编程，来 “源栈”！飞哥精品小班等着你……"},
                new Advertisements{Title=" 免费广告位，抢到就是赚到！"},
                new Advertisements{Title=" 免费广告位，抢到就是赚到！"},
                new Advertisements{Title=" 免费广告位，抢到就是赚到！"},
                new Advertisements{Title=" 免费广告位，抢到就是赚到！"},
                new Advertisements{Title=" 本站主机由西部数码提供"},
            };
            return View(Advertisements);
        }
    }
}
