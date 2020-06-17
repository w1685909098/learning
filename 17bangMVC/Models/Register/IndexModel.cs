using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _17bangMVC.Models.Register
{
    public class IndexModel
    {
        //public User User { get; set; }
        [Required]
        public string UserName { get; set; }
        [MaxLength(18,ErrorMessage ="* 密码最大长度不能超过18")]
        public string Password { get; set; }
        [Display(Name = "确认密码")]
        [Compare(nameof(Password),ErrorMessage ="* 两次密码输入不一致")]
        public string ConfirmPassword { get; set; }

    }
}