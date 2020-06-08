using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Text;

namespace CSharp.Entities
{
    public class Classroom
    {//与学生对应  一对多
        public int Id { get; set; }
        public string Name { get; set; }
        //public IList<Student> Students { get; set; }
    }
}
