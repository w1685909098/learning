using _17bang.Pages.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.Shared.Components._Ranks
{
    public class _RanksViewComponent : ViewComponent
    {
        public IList<Ranks> Ranks { get; set; }
        public IViewComponentResult Invoke()
        {
            Ranks = new List<Ranks>
            {
                new Ranks{Name="叶飞 ⑩"},
                new Ranks{Name="喵了个咪 ④"},
                new Ranks{Name="w414898760w ②"},
                new Ranks{Name="hacvk ②"},
                new Ranks{Name="wjkwjk0911 ①"},
                new Ranks{Name="18763443384 ①"},
                new Ranks{Name="dsg ①"},
                new Ranks{Name="dsg ①"},
                new Ranks{Name="苏打没有绿 ①"},
            };
            return View(Ranks);
        }
    }
}

