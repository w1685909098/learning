using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Entities
{
   public  class Bedroom
    {//与学生对应 一对一  
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Student Student { get; set; }
    }
}
