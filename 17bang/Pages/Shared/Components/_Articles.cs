using _17bang.Pages.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.Shared.Components._Articles
{
    public class _Articles : ViewComponent
    {
        public IList<Articles> Articles { get; set; }
        public IViewComponentResult Invoke()
        {
            Articles = new List<Articles>
            {
                new Articles{Title=" 关于职业选择：自己的故事"},
                new Articles{Title=" 线上学习编程注意事项"},
                new Articles{Title=" 所有关于学历的问题，一次说个够"},
                new Articles{Title=" 教程特色"},
                new Articles{Title=" ASP.NET：SEO：JavaScript/静态URL/链接权重"},
            };
            return View(Articles);
        }
    }
}