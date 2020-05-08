using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Pages.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using _17bang.Pages.ViewModel;

namespace _17bang.Pages.ProblemModel
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private ProblemRepository _repository;
        public EditModel()
        {
            _repository = new ProblemRepository();
        }
        public ViewModel.ProblemModel problem { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public void OnGet()
        {
            Id = Convert.ToInt32(Request.RouteValues["Id"]);
            problem = _repository.GetSingle(Id);
        }
        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return Page();
            }
            problem.PublishTime = DateTime.Now;
            _repository.GetSingle(Id).Update(problem);
            //_repository.SaveChanges();
            return RedirectToPage("/ProblemModel/Single",new {Id=Id});
        }
       
    } 
   
}