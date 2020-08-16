using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SqlDbContext : DbContext 
    {
        public SqlDbContext() : base("unitPro")
        {

        }
        //public DbSet<T> Entities { get; set; }
        //public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()/*.HasIndex(u => u.Name).IsUnique()*/;
            modelBuilder.Entity<Article>();
            modelBuilder.Entity<Keyword>();
            modelBuilder.ComplexType<Email>();
            modelBuilder.Entity<ArticleAndKeyword>()
                .HasKey(ak => new { /*aId =*/ ak.ArticleId, /*sId =*/ ak.KeywordId });
                

        }
    }
}
