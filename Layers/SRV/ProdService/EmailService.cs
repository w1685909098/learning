using Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProdService
{
   public  class EmailService:BaseService
    {
        string code = RandomString.GetRandomCode();
        public void ValidEmail(string address)
        {
            #region 设置邮箱内容
            MailMessage mail = new MailMessage();
            mail.From=new MailAddress("feige_20200214@163.com");
            mail.To.Add(address);
            mail.Subject = $"激活Email,邮箱验证码为{code}";
            mail.IsBodyHtml = true;   //由服务器端确定
            mail.Body = $"感谢你的Email绑定......点击<a href='https://localhost:44380/Email/Activate?Id={CurrentUserId}&code={code}'进行验证 >";
            #endregion

            #region 设置SMTP服务器
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 25;
            smtp.Credentials = new System.Net.NetworkCredential("feige_20200214@163.com", "yz17bang");
            smtp.EnableSsl = false;
            smtp.Send(mail);
            #endregion
        }
    }
}
