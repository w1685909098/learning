using CSharp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Repositories
{
    class StudentRepository:DbContext
    {
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connectString = @"Data Source=(localdb)\MSSQLLocalDB;
                                    Initial Catalog=17bang;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectString);
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
