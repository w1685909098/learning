using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    //[ComplexType]
    public class Email
    {
        public string Address { get; set; }
        public DateTime? Expires { get; set; }
        public string Code { get; set; }
        public bool IsAvtivate { get; set; }
        //public int UserId { get; set; }
        //public User Owner { get; set; }
    }
}
