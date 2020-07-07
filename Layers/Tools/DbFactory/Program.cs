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
                ArticleFactory.Create();
            }

        }
    }
}
