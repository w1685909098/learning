using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.ViewModel
{
    public class ContactNewModel
    {
        [RegularExpression("[0-9]*",ErrorMessage ="* 输入值应在0-9之间")]
        public string QQnumber { get; set; }
        public string WeChat { get; set; }
        [StringLength(maximumLength:11,MinimumLength =11,ErrorMessage ="* 请输入正确的手机号")]
        [Phone]
        public string Telephone { get; set; }
        public string Others { get; set; }
    }
}
