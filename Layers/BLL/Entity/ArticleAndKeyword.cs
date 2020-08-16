using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class ArticleAndKeyword /*:BaseEntity*/
    {
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int KeywordId { get; set; }
        public Keyword Keyword { get; set; }
    }
}
