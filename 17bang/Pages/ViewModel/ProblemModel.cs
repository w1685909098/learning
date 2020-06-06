using _17bang.Pages.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.ViewModel
{
    public class ProblemModel
    {
        public DateTime PublishTime { get; set; } /*= DateTime.Now;*/
        public User Author { get; set; }/* = new User { Name = "1", Id = 1 };*/
        public int Id { get; set; }
        public string Abstact { get; set; }
        public ProblemStatus Status { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "* 标题不能为空")]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "* 正文不能为空")]
        public string Description { get; set; }
     
        public string SelfDescription { get; set; }
        public string UserName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage  = "* 悬赏帮帮币不能为空")]
        public string RewardHelpMoneyCount { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "* 关键字1不能为空")]
        public string ProblemType { get; set; }
        public IList<SelectListItem> ProblemTypeSelects { get; set; } 
        //    new List<SelectListItem>
        //    {
        //        new SelectListItem(" 编程开发语言"," 编程开发语言"),
        //        new SelectListItem{Text="工具软件",Value="工具软件"},
        //        new SelectListItem{Text="顾问咨询",Value="顾问咨询"},
        //        new SelectListItem{Text="操作系统",Value="操作系统"},
        //    };
        [Required(AllowEmptyStrings = false, ErrorMessage = "* 关键字2不能为空")]
        public string LanguageType { get; set; }
        //public ProblemModel Update(ProblemModel model)
        //{
        //    return model;
        //}
    }
    public enum ProblemStatus
    {
        [Description("已撤销")]
        Cancelled,
        [Description("待协助")]
        WaitingProcess,
        [Description("协助中")]
        InProcess,
        [Description("已酬谢")]
        Rewarded,
    }
    public enum LanguageTypeSelects
    {
        [Display(Name = "C#")]
        CSharp,
        JAVA,
        Javascript,
        html,
        SQL,
        Python,
        CSS,
        PHP,
        [Display(Name = "C++")]
        CDouble,
        C,
    }
}
