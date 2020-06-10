using EntityFrameworkCoreSQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
  public   class Comment
    {
        public Register user { get; set; }
        public string Word { get; set; }
        public Article Article { get; set; }
        public Appraise Appraise { get; set; }
        public DateTime CreatTime { get; set; }
    }
}
