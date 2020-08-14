using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Article;

namespace ServiceInterface
{
    public interface IArticleService
    {
        ArticleModel GetByPaged(int PageSize, int PageIndex);

        ArticleSingleModel GetArticleSingelModelById(int id);

        ArticleEditModel GetArticleEditModelById(int id);


        void SaveArticleEditModel(ArticleEditModel articleEditModel);

        /*ArticleNewModel*/int UIAddArticleNewModel(ArticleNewModel articleNewModel);
    }
}
