using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _17bang.Pages.Entity;
using _17bang.Pages.Repository;

namespace _17bang.Pages.ProblemModel
{
    public class SingleModel : PageModel
    {
        public SingleModel()
        {
            _repository=new ProblemRepository();
        }
        private ProblemRepository _repository;
        public Problem Problem { get; set; }
        public void OnGet()
        {
            int Id = Convert.ToInt32(Request.RouteValues["id"]);
            Problem = _repository.GetSingle(Id);

        }
    }
}