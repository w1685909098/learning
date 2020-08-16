using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFactory
{
    internal class ArticleFactory
    {
        internal static Article xx1, tt1;
        private static ArticleRepository articleRepository;
        static ArticleFactory()
        {
            articleRepository = new ArticleRepository(Global.Context);
        }
        public static void Create()
        {
            xx1 = new Article
            {
                //Id = 1,
                PublishTime = Global.BaseTime.AddDays(-1),
                Author = RegisterFactory.xx,
                Title = "first",
                Body = "virtual",
                Keywords = new List<ArticleAndKeyword>
                {
                    new ArticleAndKeyword { Keyword = KeywordFactory.CSharp,Article = xx1 } ,
                    new ArticleAndKeyword { Keyword = KeywordFactory.SQL,Article = xx1 }
                },
                Commnets = new List<Comment>(),
                AgreeCount = 1,
                DisagreeCount = 0,
            };
            tt1 = new Article
            {
                //Id = 2,
                PublishTime = Global.BaseTime.AddDays(0),
                Author = RegisterFactory.tt,
                Title = "second",
                Body = "same",
                Keywords = new List<ArticleAndKeyword>
                 {
                    new ArticleAndKeyword { Keyword = KeywordFactory.JavaScript ,Article = tt1} ,
                    new ArticleAndKeyword { Article = tt1, Keyword = KeywordFactory.ASP },
                },
                Commnets = new List<Comment>(),
                AgreeCount = 2,
                DisagreeCount = 0
            };
            articleRepository.AddArticle(xx1);
            articleRepository.AddArticle(tt1);
            //articleRepository.AddRangeEntities(new List<Article> { xx1, tt1 });
        }
    }
}
