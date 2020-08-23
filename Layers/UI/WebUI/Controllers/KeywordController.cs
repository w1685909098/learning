using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Keyword;

namespace WebUI.Controllers
{
    [ChildActionOnly]
    public class KeywordController : BaseController
    {
        private IKeywordService _keywordService;
        public KeywordController(IKeywordService keywordService)
        {
            _keywordService = keywordService;
        }
        // GET: Keyword
        public ActionResult _Items()
        {
            IList<KeywordModel> model = _keywordService.GetRankedKeywordModels(15);
            return View(model);
        }
    }
}