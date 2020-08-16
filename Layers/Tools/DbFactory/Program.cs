using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DbFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Global.Context)
            {
                Database database = Global.Context.Database;
                database.Log = Console.Write;
                //database.Log = s => File.AppendAllText(@"", s);
                database.Delete();
                database.Create();
                RegisterFactory.Create();
                #region article   keyword 双向配置 先创建article 会报错：生成id有重复key 卡了半天
                //ArticleFactory.Create();
                //KeywordFactory.Create();
                #endregion

                #region article   keyword 单向配置  Article.Keywords有数据  keyword.Articles=null  先创建keyword   插入数据成功
                KeywordFactory.Create();
                ArticleFactory.Create();
                #endregion

                #region  article   keyword 单向配置  Article.Keywords=null  keyword.Articles有集合值  先创建article   插入数据成功
                //ArticleFactory.Create();
                //KeywordFactory.Create();
                #endregion
            }

        }
    }
}
