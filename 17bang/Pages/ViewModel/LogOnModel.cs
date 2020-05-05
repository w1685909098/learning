using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.ViewModel
{
    public class LogOnModel
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="* 用户名不能为空")]
        public string Name { get; set; }
        [MaxLength(18,ErrorMessage ="* 密码长度不能超过18")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="* 密码不能为空")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
