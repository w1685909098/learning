using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SqlContext : DbContext 
    {
        public SqlContext() : base("unitPro")
        {

        }
        //public DbSet<T> Entities { get; set; }
        //public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .Property(u => u.UserName).HasColumnName("Name");
            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();

        }
    }
}
