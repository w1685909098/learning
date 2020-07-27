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
        [Required]
        public string InviterName { get; set; }
        [Required]
        public string InvitingCode { get; set; }
        [MaxLength(10, ErrorMessage = "* 密码最大长度不能超过10")]
        [Required]
        public string UserName { get; set; }
        [MaxLength(18, ErrorMessage = "* 密码最大长度不能超过18")]
        [Required]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "* 两次输入密码不一致")]
        [Required]
        public string ComfirmPassword { get; set; }
        [Required]
        public string Captcha { get; set; }

    }
}
