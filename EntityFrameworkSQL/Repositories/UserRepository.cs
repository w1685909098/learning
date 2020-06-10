using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace EntityFrameworkSQL.Repositories
{
    class UserRepository : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserRepository():base("name = EFSQL")
        {

        }

    }
}
