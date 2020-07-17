using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFactory
{
   public  class KeywordFactory
    {
        private static KeywordRepository _keywordRepository;
        static KeywordFactory()
        {
            _keywordRepository = new KeywordRepository(Global.Context);
        }
        public static void Create()
        {
            Keyword CSharp = new Keyword
            {
                Name = "C#",
                Used = 999,
                CreateTime=Global.BaseTime.AddDays(-10)
            };
            Keyword JavaScript = new Keyword
            {
                Name = "JavaScript",
                Used = 123,
                CreateTime = Global.BaseTime.AddDays(-5)
            };
            Keyword ASP= new Keyword
            {
                Name = "ASP.NET",
                Used = 666,
                CreateTime = Global.BaseTime.AddDays(-3)
            }; Keyword SQL = new Keyword
            {
                Name = "SQL",
                Used = 888,
                CreateTime = Global.BaseTime.AddDays(-1)
            };
            _keywordRepository.Add(CSharp);
            _keywordRepository.Add(JavaScript);
            _keywordRepository.Add(ASP);
            _keywordRepository.Add(SQL);
        }
    }
}
