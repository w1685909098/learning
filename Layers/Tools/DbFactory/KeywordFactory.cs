using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFactory
{
    public class KeywordFactory
    {
        private static KeywordRepository _keywordRepository;
        static KeywordFactory()
        {
            _keywordRepository = new KeywordRepository(Global.Context);
        }
        internal static Keyword CSharp, JavaScript, ASP, SQL;
        public static void Create()
        {
            CSharp = new Keyword
            {
                //Id = 1,
                Name = "C#",
                Used = 999,
                CreateTime = Global.BaseTime.AddDays(-10),
                Articles = new List<ArticleAndKeyword>
                {
                    //new ArticleAndKeyword{Article=ArticleFactory.xx1,Keyword=CSharp}
                }
            };
            JavaScript = new Keyword
            {
                //Id = 2,
                Name = "JavaScript",
                Used = 123,
                CreateTime = Global.BaseTime.AddDays(-5),
                Articles = new List<ArticleAndKeyword>
                {
                    //new ArticleAndKeyword{Article=ArticleFactory.tt1,Keyword=JavaScript}
                }
            };
            ASP = new Keyword
            {
                //Id = 3,
                Name = "ASP.NET",
                Used = 666,
                CreateTime = Global.BaseTime.AddDays(-3),
                Articles = new List<ArticleAndKeyword>
                {
                    //new ArticleAndKeyword{Article=ArticleFactory.tt1,Keyword=ASP}
                }
            };
            SQL = new Keyword
            {
                //Id = 4,
                Name = "SQL",
                Used = 888,
                CreateTime = Global.BaseTime.AddDays(-1),
                Articles = new List<ArticleAndKeyword>
                {
                    //new ArticleAndKeyword{Article=ArticleFactory.xx1,Keyword=SQL}
                }
            };
            _keywordRepository.AddEntity(CSharp);
            _keywordRepository.AddEntity(JavaScript);
            _keywordRepository.AddEntity(ASP);
            _keywordRepository.AddEntity(SQL);
            //_keywordRepository.AddRangeEntities(new List<Keyword> { CSharp, JavaScript, ASP, SQL });
        }
    }
}
