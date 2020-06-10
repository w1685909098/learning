using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Entities
{
    public  class StudentAndTeacher
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
