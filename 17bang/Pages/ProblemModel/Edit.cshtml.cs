using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Pages.Filter;
using _17bang.Pages.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using _17bang.Pages.ViewModel;

namespace _17bang.Pages.ProblemModel
{
    //[NeedLogOn]
    [BindProperties]
    public class EditModel : PageModel
    {
        private ProblemRepository _repository;
        public EditModel()
        {
            _repository = new ProblemRepository();
        }
        public ViewModel.ProblemModel Problem { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public ActionResult OnGet()
        {
            Id = Convert.ToInt32(Request.RouteValues["Id"]);
            Problem = _repository.GetSingle(Id);
            //if (HttpContext.Request.Cookies["UserName"] != problem.Author.Name)
            //{
            //    throw new Exception("用户权限不正确，您不是当前文章的发布者或者管理员，无权修改该文章");
            //}
            return Page();
        }
        public ActionResult OnPost()
        {
            Id = Convert.ToInt32(Request.RouteValues["Id"]);
            if (ModelState.IsValid)
            {
                return Page();
            }
            #region 没有SQL操作修改
            //_repository.GetSingle(Id).PublishTime = problem.PublishTime;
            //_repository.GetSingle(Id).Title = problem.Title;
            //_repository.GetSingle(Id).Abstact = problem.Abstact;
            #endregion
            //_repository.GetSingle(Id).Update(problem);
            //_repository.SaveChanges();
            Problem.Id = Id;
            _repository.Update(Problem);
            return RedirectToPage("/ProblemModel/Single",new {Id=Id});
        }
       
    } 
   
}