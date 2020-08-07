using Entity;
using Extension;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProdService
{
    public class EmailService : BaseService, IEmailService
    {
        string code = RandomString.GetRandomCode();
        public bool BindEmail(int userId, string code)
        {
            //Email CurrentEmail = userRepository.Find(userId).BindingEmail;
            //if (DateTime.Now > CurrentEmail.Expires)
            //{
            //    return false;
            //}
            //return code == CurrentEmail.Code;//判断code是否正确
            return false;
        }

        public void ValidEmail(string address)
        {
            #region 设置邮箱内容
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("feige_20200214@163.com");
            mail.To.Add(address);
            mail.Subject = $"激活Email,邮箱验证码为{code}";
            mail.IsBodyHtml = true;   //由服务器端确定
            mail.Body = $"感谢你的Email绑定......点击<a href='https://localhost:44380/Email/Activate?id={CurrentUserId}&code={code}'进行验证 >";
            #endregion

            #region 设置SMTP服务器
            SmtpClient smtp = new SmtpClient("smtp.163.com");
            smtp.Port = 25;
            smtp.Credentials = new System.Net.NetworkCredential("feige_20200214@163.com", "yz17bang");
            smtp.EnableSsl = false;
            smtp.Send(mail);
            #endregion
        }
    }
}
