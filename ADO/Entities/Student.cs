using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsMale { get; set; }
        public DateTime BirthDay { get; set; }
        public IList<StudentAndTeacher> Teachers { get; set; }
        public Bedroom Bed { get; set; }
        public int BedId { get; set; }
        public Classroom Classroom { get; set; }
    }


}
