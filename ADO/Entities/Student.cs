using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Entities
{
    public class Student
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public virtual bool IsMale { get; set; }
        public virtual DateTime BirthDay { get; set; }
        public virtual IList<StudentAndTeacher> Teachers { get; set; }
        public virtual Bedroom Bed { get; set; }
        public virtual int BedId { get; set; }
        public virtual int ClassroomId { get; set; }
        public virtual Classroom Classroom { get; set; }
    }


}
