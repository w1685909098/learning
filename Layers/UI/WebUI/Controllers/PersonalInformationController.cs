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
        private IPersonalInforService _personalInforService;
        public PersonalInformationController(IPersonalInforService personalInforService)
        {
            _personalInforService = personalInforService;
        }
        // GET: PersonalInformation
        public ActionResult Index()
        {
            PersonalInformationModel model = _personalInforService.GetPersonalInforModelById((int)currentId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Index( HttpPostedFileBase Icon)
        {
            PersonalInformationModel model = _personalInforService.GetPersonalInforModelById((int)currentId);
            string urlPath = "/Images";
            string iconName = Guid.NewGuid().ToString() + Path.GetExtension(Icon.FileName);
            Icon.SaveAs(Server.MapPath(urlPath) + "\\" + iconName);
            model.IconPath = urlPath + "/" + iconName;
            _personalInforService.AddModelIcon(model);
            return View(model);
        }
    }
}