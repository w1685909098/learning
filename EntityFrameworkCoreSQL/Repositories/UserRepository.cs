using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreSQL.Repositories
{
    class UserRepository:DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectionString= @"Data Source=(localdb)\MSSQLLocalDB;
                                    Initial Catalog=CoreSQL;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString)
#if DEBUG
                .EnableSensitiveDataLogging()
#endif
               .UseLoggerFactory(new LoggerFactory(
                   new ILoggerProvider[]
                   {
                       new DebugLoggerProvider()
                   }));
        }
    }
}
