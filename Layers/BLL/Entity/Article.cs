using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Article
    {
        public DateTime PublishTime { get; set; }
        public User Author { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
        public string Body { get; set; }
        public IList<Keyword> Keywords { get; set; }
        public IList<Comment> Commnets { get; set; }
        public int AgreeCount { get; set; }
        public int DisagreeCount { get; set; }

    }
}
