using Entity;
using Repository;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Article;

namespace ProdService
{
    public class ArticleService : BaseService, IArticleService
    {
        private ArticleRepository _articleRepository;
        public ArticleService()
        {
            _articleRepository = new ArticleRepository(context);
        }
        public ArticleModel GetByPaged(int PageSize, int PageIndex)
        {
            //ArticleRepository articleRepository = new ArticleRepository(context);
            //return articleRepository.GetArticles().Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
            IList<Article> articles = _articleRepository.GetPaged(PageSize, PageIndex);
            //IndexModel model = new IndexModel
            //{
            //    Items = new List<ArticleItemModel>()
            //};
            //foreach (var item in articles)
            //{
            //    //#region 手动赋值
            //    //model.Items.Add(new ArticleItemModel
            //    //{
            //    //    PublishTime = item.PublishTime,
            //    //    AuthorName = item.Author.Name,
            //    //    Title = item.Title,
            //    //    Id=item.Id,
            //    //    Body = item.Body,
            //    //    Keywords = item.Keywords,
            //    //    CommnetCount = item.Commnets.Count,
            //    //    AgreeCount = item.AgreeCount,
            //    //    DisagreeCount = item.DisagreeCount
            //    //});
            //    //#endregion
            //    model.Items.Add(mapper.Map<ArticleItemModel>(item));
            //}
            ArticleModel model = new ArticleModel
            {
                Items = new List<ArticleItemModel>()
            };
            model.Items = mapper.Map<IList<ArticleItemModel>>(articles);
            return model;
        }
    }
}
