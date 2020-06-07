using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Pages.Filter;
using _17bang.Pages.Repository;
using _17bang.Pages.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _17bang.Pages.Problem
{
    [NeedLogOn]
    [BindProperties]
    public class NewModel : PageModel
    {
        private ProblemRepository _problemrepository;
        public NewModel()
        {
            _problemrepository = new ProblemRepository();
        }

       public ViewModel.ProblemModel  Model { get; set; }
     
        public IActionResult OnGet()
        {
            Model = new ViewModel.ProblemModel
            {
                ProblemTypeSelects = new List<SelectListItem>
                {
                new SelectListItem(" 编程开发语言"," 编程开发语言"),
                new SelectListItem{Text="工具软件",Value="工具软件"},
                new SelectListItem{Text="顾问咨询",Value="顾问咨询"},
                new SelectListItem{Text="操作系统",Value="操作系统"},
                }
            };
            return Page();
        }
        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Model.ProblemType))
            {
                ModelState.AddModelError("Model.ProblemType", "* 关键字1不能为空");
            }
            if (string.IsNullOrWhiteSpace(Model.LanguageType))
            {
                ModelState.AddModelError("Model.LanguageType", "* 关键字2不能为空");
            }
            if (string.IsNullOrWhiteSpace(Model.RewardHelpMoneyCount))
            {
                ModelState.AddModelError("Model.RewardHelpMoneyCount", "* 悬赏帮帮币不能为空");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _problemrepository.ProblemNew(Model);
            return Redirect($"/ProblemModel/{Model.Id}");
            //return RedirectToPage("/ProblemModel/Single");
        }
    }
}