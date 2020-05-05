using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.Entity
{
    public class Message
    {
        public int Id { get; set; }
        public bool Selected { get; set; }
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }

    }
}
