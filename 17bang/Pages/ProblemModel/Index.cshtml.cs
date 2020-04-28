using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _17bang.Pages.Repository;
using _17bang.Pages.Entity;

namespace _17bang.Pages.ProblemModel
{
    public class IndexModel : PageModel
    {
        public IndexModel()
        {
            _repository = new ProblemRepository();
        }
        private ProblemRepository _repository;
        public IList<Problem> Problems { get; set; }
        public string Exclude { get; set; }
        public int PageIndex { get;set; }
        public int SumOfProblems;
        public int SumOfExcludeProblems;
        public void OnGet()
        {
             Exclude = Request.Query["exclude"];
            if (string.IsNullOrEmpty(Exclude))
            {
                Problems = _repository.GetProblems();
            }
            else
            {
                Problems = _repository.GetExclude(Enum.Parse<ProblemStatus>(Exclude));
                SumOfExcludeProblems = Problems.Count;
            }
            PageIndex = Convert.ToInt32(Request.Query["pageIndex"]);
            Problems = _repository.GetPaged(Problems,PageIndex, Const.PageSize);
            SumOfProblems = _repository.GetSum();
        }
        public void OnPost()
        {

        }
    }
}