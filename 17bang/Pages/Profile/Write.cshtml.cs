using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Pages.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _17bang.Pages.Profile
{
    [BindProperties]
    public class WriteModel : PageModel
    {
        public ProfileWriteModel Model { get; set; }

        public void OnGet()
        {
            Model = new ProfileWriteModel
            {
                BirthMonths = new List<SelectListItem>
            {
                new SelectListItem("1","1"),
                new SelectListItem{Text="3",Value="3"},
                new SelectListItem{Text="5",Value="5"},
                new SelectListItem{Text="7",Value="7"},
                new SelectListItem{Text="9",Value="9"},
                new SelectListItem{Text="11",Value="11"},
            },
                BirthYears = new List<SelectListItem>{
                new SelectListItem("1950","1950"),
                new SelectListItem{Text="1980",Value="1980"},
                new SelectListItem{Text="1990",Value="1990"},
                new SelectListItem{Text="2000",Value="2000"},
                new SelectListItem{Text="2010",Value="2010"},
                new SelectListItem{Text="2020",Value="2020"},
            }
            };
    }
        public void OnPost()
        {
            if (Model.BirthYear == null)
            {
                ModelState.AddModelError("Model.BirthYear", " * 生日年份不能为空");
            }
            if (!ModelState.IsValid)
            {
                return;
            }

        }
    }
}