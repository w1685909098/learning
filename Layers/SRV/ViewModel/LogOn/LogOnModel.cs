using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.LogOn
{
   public  class LogOnModel
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //public bool RememberMe { get; set; }
        public string Captcha { get; set; }
    }
}
