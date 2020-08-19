using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModel.Keyword;

namespace ViewModel.Article
{
   public class ArticleNewModel
    {
        public DateTime PublishTime { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "* 文章标题不能为空")]
        public string Title { get; set; }

        public int? Id { get; set; }

        [AllowHtml]
        [Required(AllowEmptyStrings = false, ErrorMessage = "* 文章正文不能为空")]
        public string Body { get; set; }

        //public IList<KeywordModel> KeywordModels { get; set; }
        //public string Keywords { get; set; }
       
    }
}
