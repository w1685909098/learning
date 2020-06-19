using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Article;

namespace ProdService
{
    public class ArticleService
    {
        public IndexModel GetBy(int PageSize,int PageIndex)
        {
            ArticleRepository articleRepository = new ArticleRepository();
            //return articleRepository.GetArticles().Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
            IList<Article> articles = articleRepository.GetPaged(PageSize,PageIndex);
            IndexModel model = new IndexModel
            {
                Items = new List<ArticleItemModel>()
            };
            foreach (var item in articles)
            {
                model.Items.Add(new ArticleItemModel
                {
                    PublishTime = item.PublishTime,
                    AuthorName = item.Author.UserName,
                    Title = item.Title,
                    Body = item.Body,
                    Keywords=item.Keywords,
                    CommnetCount = item.Commnets.Count,
                    AgreeCount = item.AgreeCount,
                    DisagreeCount=item.DisagreeCount

                }) ;
            }
            return model ;
        }
    }
}
