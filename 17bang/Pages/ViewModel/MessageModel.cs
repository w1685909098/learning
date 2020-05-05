using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.ViewModel
{
    public class MessageModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public bool Selected { get; set; }

    }
}
