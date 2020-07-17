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
        [Required]
        public string UserName { get; set; }
        [MaxLength(18, ErrorMessage = "* 密码最大长度不能超过18")]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "* 两次输入密码不一致")]
        public string ComfirmPassword { get; set; }
    }
}
