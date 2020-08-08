using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Register
{
    public class UserModel
    {
        public int? UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* 邀请人不能为空")]
        public string InviterName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* 邀请码不能为空")]
        public string InvitingCode { get; set; }

        [MaxLength(10, ErrorMessage = "* 密码最大长度不能超过10")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "* 用户名不能为空")]
        public string UserName { get; set; }

        [MaxLength(18, ErrorMessage = "* 密码最大长度不能超过18")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "* 密码不能为空")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "* 两次输入密码不一致")]
        [Required]
        public string ComfirmPassword { get; set; }

        [Required]
        public string Captcha { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* 邮箱不能为空")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* 验证码不能为空")]
        public string EmailCode { get; set; }

        public DateTime ExprieTime { get; set; }

        public bool EmailIsActivate { get; set; }

        //public DateTime InputTime { get; set; }

    }
}
