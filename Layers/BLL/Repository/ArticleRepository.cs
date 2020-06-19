using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ArticleRepository
    {
        private IList<Article> _articles;
        public ArticleRepository()
        {
            _articles = new List<Article>();
        }
        //public IList<Article> GetArticles()
        //{
        //    return _articles;
        //}
        public IList<Article> GetPaged(int PageSize, int PageIndex)
        {
            return _articles.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
        }
    }
}
