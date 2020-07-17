using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Keyword;

namespace ServiceInterface
{
   public  interface IKeywordService
    {
        IList<KeywordModel> GetRankedKeywordModels(int maxCount);
    }
}
