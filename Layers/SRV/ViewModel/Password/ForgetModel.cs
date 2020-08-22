using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Password
{
    public class ForgetModel
    {
        public int? Id { get; set; }
        [Required]
        [EmailAddress]//正则表达式实现
        public string EmailAddress { get; set; }


        public string UserName { get; set; }

        [Required]
        public string VerificationCode { get; set; }

    }
}
