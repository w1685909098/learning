using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _17bang.Pages.Entity;
using _17bang.Pages.Repository;
using _17bang.Pages.ViewModel;
using Microsoft.AspNetCore.Http;

namespace _17bang.Pages.Message
{
    [BindProperties]
    public class MineModel : PageModel
    {
        public MineModel()
        {
            _repositiry = new MessageRepository();
        }
        private MessageRepository _repositiry;
        public IList<MessageModel> Messages { get; set; }
        public ActionResult OnGet()
        {
            Messages = _repositiry.Get();
            return Page();
        }
        public ActionResult OnPost()
        {
            #region 自己写的
            //_repositiry.IsRead(Messages);
            //_repositiry.Delete(Messages);
            #endregion
           
            foreach (var message in Messages)
            {
                if (message.Selected)
                {
                    if (Request.RouteValues["opt"].ToString()=="read")
                    {
                        _repositiry.GetSingleMessage(message.Id).IsRead = true;
                        //_repositiry.Save();

                    }
                    else if (Request.RouteValues["opt"].ToString() == "delete")
                    {
                        //_repositiry.Delete(_repositiry.GetSingleMessage(message.Id));
                        _repositiry.Delete(message.Id);
                    }
                    else
                    {
                        throw new Exception(" 未知的处理情况");
                    }
                }
            }

            return Redirect("/Message/Mine");
        }
    }

}