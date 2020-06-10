using Entities;
using EntityFrameworkCoreSQL.Entities;
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
        public DbSet<Register> Users { get; set; }
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Register>().ToTable("User")
            .Property(r=>r.UserName).HasColumnName("Name")
            .HasMaxLength(255);
            modelBuilder.Entity<Register>().Property(r => r.Password).IsRequired();
            modelBuilder.Entity<Register>().HasKey(r => r.UserName);
            modelBuilder.Entity<Register>().Ignore (r => r.FailedTry);
            modelBuilder.Entity<Register>().HasIndex(r=>r.CreateTime);
            modelBuilder.Entity<Register>()
                .HasOne<Email>(r => r.Email)
                .WithOne(e => e.Register)
                .HasForeignKey<Register>(r=>r.EmailId);
        }
    }
}
