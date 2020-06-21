using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SqlContext :DbContext
    {
        public DbSet<BaseEntity> Entities { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
