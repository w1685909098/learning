using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.ViewModel
{
    public class UserModel
    {
        public int Id { get; set; }
        [StringLength(10,MinimumLength =1,ErrorMessage ="* 用户名长度不能超过10")]
        [Required(AllowEmptyStrings =false,ErrorMessage =("* 必须输入用户名"))]
        public  string Name { get; set; }
        [MaxLength(18,ErrorMessage ="* 密码长度不能超过18")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ("* 必须输入密码"))]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="* 两次输入密码不一致")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ("* 必须输入验证密码"))]
        [DataType(DataType.Password)] 
        public string ConfirmPassword { get; set; }
    }
}
