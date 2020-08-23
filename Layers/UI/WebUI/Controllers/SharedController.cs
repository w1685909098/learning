using Extension;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        public ActionResult Captcha()
        {
            //return View();
            //父类装子类
            //FileResult file = new FileContentResult();
            //file = new FileStreamResult();
            //file=new FilePathResult();
            /*return File("TrainUpFile.txt","text/plain","Training"); */ //文件名字，文件格式，文件下载名字
            Bitmap image = new Bitmap(100, 30);    //生成图片
            Graphics drawing = Graphics.FromImage(image);  //生成画板
            drawing.Clear(Color.White); //清空画板
            string captcha = RandomString.GetRandomCode();
            drawing.DrawString(captcha, new Font("宋体", 14), 
                new SolidBrush(Color.Black), new Point(25, 5));
            Session["captcha"] = captcha;
            MemoryStream stream = new MemoryStream();
            image.Save(stream,ImageFormat.Jpeg);
            return File(stream.ToArray(), "image/png");
        }
        //public static string GetCaptcha()
        //{
        //    int length = 4;
        //    string whiteList = "0123456789";
        //    Random random = new Random();
        //    string captcha = null;
        //    for (int i = 0; i < length; i++)
        //    {
        //        int indexRandom = random.Next(whiteList.Length);
        //        char singleChar = whiteList[indexRandom];
        //        captcha += singleChar; 
        //    }
        //    return captcha;
        //}
    }
}