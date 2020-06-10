using CSharp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Repositories
{
    public class TeacherRepository:BaseRepository<Teacher>
    {
        public TeacherRepository() :base()
        {

        }
        public TeacherRepository(SqlContext context) :base(context)
        {

        }

        public Teacher GetByName(string name)
        {
            return SqlContext.Teachers.Where(t => t.Name == name).SingleOrDefault();
        }
    }
}
