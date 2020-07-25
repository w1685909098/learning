using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        public ActionResult Index()
        {
            //return View();
            //父类装子类
            //FileResult file = new FileContentResult();
            //file = new FileStreamResult();
            //file=new FilePathResult();
            return File("TrainUpFile.txt","text/plain","Training");  //文件名字，文件格式，文件下载名字
        }
    }
}