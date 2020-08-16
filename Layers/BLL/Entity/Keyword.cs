using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public  class Keyword :BaseEntity
    {
        public string Name { get; set; }
        public int Used { get; set; }
        public DateTime CreateTime { get; set; }
        public IList<ArticleAndKeyword> Articles { get; set; }
    }
}
