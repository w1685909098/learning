using Entity;
using Repository;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Keyword;

namespace ProdService
{
   public  class KeywordService:BaseService,IKeywordService
    {
        private KeywordRepository _keywordRepository;
        public KeywordService()
        {
            _keywordRepository = new KeywordRepository(context);
        }
        public IList<KeywordModel> GetRankedKeywordModels(int maxCount)
        {
            IList<Keyword> keywords = _keywordRepository.GetRankedKeywords(maxCount);
            return mapper.Map<IList<KeywordModel>>(keywords);
        }
    }
}
