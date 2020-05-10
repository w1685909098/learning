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
     
        public void OnGet()
        {

        }
        public void OnPost()
        {
            //if (string.IsNullOrWhiteSpace(Model.ProblemType) )
            //{
            //    ModelState.AddModelError("Model.ProblemType",  "* 关键字不能为空");
            //}
            //if (string.IsNullOrWhiteSpace(Model.LanguageType) )
            //{
            //    ModelState.AddModelError("Model.LanguageType", "* 关键字不能为空");
            //}
            if (string.IsNullOrWhiteSpace(Model.RewardHelpMoneyCount) )
            {
                ModelState.AddModelError("odel.RewardHelpMoneyCount", "* 悬赏帮帮币不能为空");

            }
            if (!ModelState.IsValid)
            {
                return;
            }
            _problemrepository.ProblemSave(Model);
        }
    }
}