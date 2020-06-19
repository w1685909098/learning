using Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Article
{
    public class IndexModel
    {
        public IList<ArticleItemModel> Items { get; set; }
    }

    public class ArticleItemModel
    {
        public DateTime PublishTime { get; set; }
        public string AuthorName { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
        public string Body { get; set; }
        public IList<Keyword> Keywords { get; set; }
        public int CommnetCount { get; set; }
        public int AgreeCount { get; set; }
        public int DisagreeCount { get; set; }
    }
}
