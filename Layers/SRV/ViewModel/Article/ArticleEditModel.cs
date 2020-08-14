using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Keyword;

namespace ViewModel.Article
{
   public class ArticleEditModel
    {
        public DateTime PublishTime { get; set; }

        public string AuthorName { get; set; }

        public int AuthorId { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="* 文章标题不能为空")]
        public string Title { get; set; }

        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* 文章正文不能为空")]
        public string Body { get; set; }

        //public IList<KeywordModel> KeywordModels { get; set; }

        public int CommnetCount { get; set; }

        public int AgreeCount { get; set; }

        public int DisagreeCount { get; set; }
    }
}
