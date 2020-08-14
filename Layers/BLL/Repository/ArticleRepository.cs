using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ArticleRepository : BaseRepository<Article>
    {
        //private IList<Article> _articles;
        //public ArticleRepository()
        //{
        //    _articles = new List<Article>();
        //}
        //public IList<Article> GetArticles()
        //{
        //    return _articles;
        //}
        public ArticleRepository(DbContext conetext) : base(conetext)
        {

        }
        public IList<Article> GetPaged(int PageSize, int PageIndex)
        {
            return Entities.Include(e=>e.Author).OrderBy(e => e.PublishTime).
                Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
        }
        public int AddArticle(Article article)
        {
            Entities.Add(article);
            context.SaveChanges();
            return article.Id;
        }
        public void SaveArticleChanges(Article article)
        {
            article.PublishTime = DateTime.Now;
            Entities.AddOrUpdate(article);
            context.SaveChanges();
        }
    }
}
