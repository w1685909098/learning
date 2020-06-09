using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Entities
{
    public  class StudentAndTeacher
    {
        public virtual int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public virtual int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
