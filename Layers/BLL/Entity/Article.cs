using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Article :BaseEntity
    {
        public DateTime PublishTime { get; set; }
        public int UserId { get; set; }  //影子属性
        public User Author { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public IList<ArticleAndKeyword> Keywords { get; set; }
        public IList<Comment> Commnets { get; set; }
        public int AgreeCount { get; set; }
        public int DisagreeCount { get; set; }

        public void ArticlePublish()
        {
            Author.BMoney -= 1;
            Author.Credit += 10;
        }

    }
}
