using ProdService;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using System.Web.UI;
using ViewModel.Article;

namespace WebUI.Controllers
{
    public class ArticleController : BaseController
    {
        private IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        // GET: Article
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                id = 1;
            }
            int PageSize = 2;
            ArticleModel model = _articleService.GetByPaged(PageSize, (int)id);
            return View(model);
        }
        public ActionResult Single(int id)
        {
            ArticleSingleModel articleSingleModel = _articleService.GetArticleSingelModelById(id);
            return View(articleSingleModel);
        }
        //[ValidateInput(enableValidation:false)]
        public ActionResult Edit(int id )
        {
            ArticleEditModel ArticleEditModel = _articleService.GetArticleEditModelById(id);
            return View(ArticleEditModel);
        }
        [HttpPost]
        public ActionResult Edit(int id,ArticleEditModel model)
        {
            if (model.Title==null)
            {
                ModelState.AddModelError(nameof(model.Title), "* 文章标题不能为空");
                return View(model);
            }
            if (model.Body==null)
            {
                ModelState.AddModelError(nameof(model.Body), "* 文章正文不能为空");
                return View(model);
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ArticleEditModel editModel = _articleService.GetArticleEditModelById(id);
            editModel.PublishTime = DateTime.Now;
            editModel.Title = model.Title;
            editModel.Body = model.Body;
            _articleService.SaveArticleEditModel(editModel);
            //ArticleEditModel ArticleUpdateModel = _articleService.GetArticleEditModelById(id);
            return RedirectToAction("Single", new { id = id });
        }
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(ArticleNewModel model)
        {
            if (model.Title == null)
            {
                ModelState.AddModelError(nameof(model.Title), "* 文章标题不能为空");
                return View(model);
            }
            if (model.Body == null)
            {
                ModelState.AddModelError(nameof(model.Body), "* 文章正文不能为空");
                return View(model);
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.PublishTime = DateTime.Now;
            int newId = _articleService.UIAddArticleNewModel(model);
            return RedirectToAction("Single",new { id=newId});
        }
    }
}