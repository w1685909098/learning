using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.Entity
{
    public class User
    {
        public string Name { get; set; }
        public string Password;
        public string VerifivationCode;
        public int Id;
    }
}
