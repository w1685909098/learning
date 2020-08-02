using ServiceInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using ViewModel.Personal;

namespace WebUI.Controllers
{
    public class PersonalInformationController : BaseController
    {
        //private IRegisterService _registerService;
        //public PersonalInformationController(IRegisterService registerService)
        //{
        //    _registerService = registerService;
        //}
        // GET: PersonalInformation
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(PersonalInformationModel model,HttpPostedFileBase icon)
        {
            //PersonalInformationModel model=_registerService
            //string urlPath = "/Images";
            //string iconName = Guid.NewGuid().ToString() + Path.GetExtension(icon.FileName);
            //icon.SaveAs(Server.MapPath(urlPath) + "\\" + iconName);
            //model.IconPath = urlPath + "/" + iconName;
            return View();
        }
    }
}