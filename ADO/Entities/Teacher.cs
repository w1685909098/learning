using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Entities
{
   public  class Teacher
    {//与学生对应多对多
        public int Id { get; set; }
        public string Name { get; set; }
        public int? age { get; set; }
        public IList<StudentAndTeacher> Students { get; set; }
    }
}
