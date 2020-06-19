using ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index(int PageIndex)
        {
            int PageSize = 10;
            ArticleService articleService = new ArticleService();
            articleService.GetBy(PageSize, PageIndex);
            return View();
        }
        public ActionResult Single(int Id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int Id)
        {
            return View();
        }
    }
}