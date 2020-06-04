using CSharp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CSharp.Repositories
{
      public class StudentRepository:DbContext
    {
        public StudentRepository():base("name=databaseConnect")
        {

        }
        public DbSet<Student> Students { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    string connectString = @"Data Source=(localdb)\MSSQLLocalDB;
        //                            Initial Catalog=222;Integrated Security=True;";
        //    optionsBuilder.UseSqlServer(connectString);
        //}
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
