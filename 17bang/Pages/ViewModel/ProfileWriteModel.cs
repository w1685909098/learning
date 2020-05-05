using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.ViewModel
{
    public class ProfileWriteModel
    {
        public bool? IsMale { get; set; }
        public string BirthYear { get; set; }
        public IList<SelectListItem> BirthYears { get; set; } /*= new List<SelectListItem>*/
        //    {
        //        new SelectListItem("1950","1950"),
        //        new SelectListItem{Text="1980",Value="1980"},
        //        new SelectListItem{Text="1990",Value="1990"},
        //        new SelectListItem{Text="2000",Value="2000"},
        //        new SelectListItem{Text="2010",Value="2010"},
        //        new SelectListItem{Text="2020",Value="2020"},
        //    };
        public string BirthMonth { get; set; }
        public IList<SelectListItem> BirthMonths { get; set; } /*= new List<SelectListItem>*/
        //   {
        //        new SelectListItem("1","1"),
        //        new SelectListItem{Text="3",Value="3"},
        //        new SelectListItem{Text="5",Value="5"},
        //        new SelectListItem{Text="7",Value="7"},
        //        new SelectListItem{Text="9",Value="9"},
        //        new SelectListItem{Text="11",Value="11"},
        //   };
        public string SelfDescription { get; set; }
    }
}
