using CSharp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Repositories
{
   public  class StudentRepository:DbContext
    {
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectString = @"Data Source=(localdb)\MSSQLLocalDB;
                                    Initial Catalog=222;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectString);
//#if DEBUG
//            .EnableSensitiveDataLogging(true)
//#endif
//            .UseLoggerFactory(new LoggerFactory(new ILoggerProvider[]
//            {
//                new DebugLoggerProvider()
//            }));
        }
        public void SaveStudent(Student student)
        {
            Students.Add(student);
            
        }
        public Student GetStudentById (int Id)
        {
            return Students.Where(s => s.Id == Id).SingleOrDefault();
        }
    }
}
