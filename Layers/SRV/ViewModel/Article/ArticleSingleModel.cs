using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Keyword;

namespace ViewModel.Article
{
   public class ArticleSingleModel
    {
        public DateTime PublishTime { get; set; }

        public string AuthorName { get; set; }

        public int AuthorId { get; set; }

        public string Title { get; set; }

        public int Id { get; set; }

        public string Body { get; set; }

        public IList<KeywordModel> KeywordModels { get; set; }

        public int CommnetCount { get; set; }

        public int AgreeCount { get; set; }

        public int DisagreeCount { get; set; }

    }

}
