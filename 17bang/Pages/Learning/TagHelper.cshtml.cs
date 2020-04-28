using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _17bang.Pages.Learning
{
    [BindProperties]
    public class TagHelperModel : PageModel
    {
        public string name { get; set; }
        public string password { get; set; }
        [DataType(DataType.Password)]
        public string checkpassword { get; set; }
        public bool? male { get; set; }
        public string choice { get; set; }
        public IList<SelectListItem> lists { get; set; } =
            new List<SelectListItem> 
            {
                new  SelectListItem("1","one"),
                new SelectListItem{Text="2",Value="two"},
            };
        public IList<List> Options { get; set; }
        public void OnGet()
        {
            Options = new List<List>
            { 
                new List{Id=11,Selected=false},
                new List{Id=22,Selected=false},
                new List{Id=33,Selected=false},
                new List{Id=44,Selected=false},
                new List{Id=55,Selected=false},
            };
        }
        public void OnPost()
        {

        }
    }
    public class List
    {
        public int Id { get; set; }
        public bool Selected { get; set; }
    }
}