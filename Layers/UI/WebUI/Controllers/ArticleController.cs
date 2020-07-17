using ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using ViewModel.Article;

namespace WebUI.Controllers
{
    public class ArticleController : Controller
    {
        int PageIndex = 1;
        // GET: Article
        public ActionResult Index(int PageIndex = 1)
        {
            int PageSize = 10;
            ArticleModel model = new ArticleService().GetBy(PageSize, PageIndex);
            return View(model);
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