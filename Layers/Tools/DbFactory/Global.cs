using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFactory
{
   public class Global
    {
        public static DateTime BaseTime = DateTime.Now;
        public static SqlDbContext Context = new SqlDbContext();
    }
}
