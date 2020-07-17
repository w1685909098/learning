using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel.Keyword;

namespace WebUI.Controllers
{
    public class KeywordController : Controller
    {
        private IKeywordService _keywordService;
        public KeywordController(IKeywordService keywordService)
        {
            _keywordService = keywordService;
        }
        // GET: Keyword
        public PartialViewResult _Items()
        {
            IList<KeywordModel> model = _keywordService.GetRankedKeywordModels(15);
            return PartialView(model);
        }
    }
}