using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.ViewModel
{
    public class PasswordForgetModel
    {
        [EmailAddress]
        public string Email { get; set; }
        [EmailAddress]
        public string SearchEmail { get; set; }
        public string QQnumber { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="* 验证码不能为空")]
        public string VerificationCode { get; set; }
    }
}
