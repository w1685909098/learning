using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Entities
{
   public  class Bedroom
    {//与学生对应 一对一  
        public int Id { get; set; }
        public string Name { get; set; }
        public Student Student { get; set; }
    }
}
