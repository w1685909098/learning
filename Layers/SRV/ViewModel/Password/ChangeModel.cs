using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Password
{
   public  class ChangeModel
    {
        public int? Id { get; set; }

        [Required]
        public string PresentPassword { get; set; }

        [Required]
        public string UpdatePassword { get; set; }

        [Compare(nameof(UpdatePassword),ErrorMessage ="* 两次输入密码不一致，请重新输入确认密码")]
        [Required]
        public string ComfirmPassword { get; set; }
    }
}
