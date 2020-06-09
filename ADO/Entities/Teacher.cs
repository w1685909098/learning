using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Entities
{
   public  class Teacher
    {//与学生对应多对多
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int? age { get; set; }
        public virtual IList<StudentAndTeacher> Students { get; set; }
    }
}
