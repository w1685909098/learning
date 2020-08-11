using Entity;
using Extension;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using ViewModel.Register;

namespace ProdService
{
    public class EmailService : BaseService, IEmailService
    {
        string code = RandomString.GetRandomCode();
        public bool BindEmail(int userId, string code)
        {
            User user = userRepository.Find(userId);
            if (DateTime.Now>user.BindingEmail.Expires)
            {
                return false;
            }
            return code==user.BindingEmail.Code;
        }

        public UserModel GetUserModelByName(string name)
        {
            return mapper.Map<UserModel>(userRepository.GetUserByName(name));
        }

        public void ValidEmail(string mailSubject, string address, string mailBody)
        {
            #region 设置邮箱内容
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("feige_20200214@163.com");
            mail.To.Add(address);
            mail.Subject = mailSubject;
            mail.IsBodyHtml = true;   //由服务器端确定
            mail.Body = mailBody;
            #endregion

            #region 设置SMTP服务器
            SmtpClient smtp = new SmtpClient("smtp.163.com");
            smtp.Port = 25;
            smtp.Credentials = new System.Net.NetworkCredential("feige_20200214@163.com", "yz17bang");
            smtp.EnableSsl = false;
            smtp.Send(mail);
            #endregion
        }

        public void SendEmail(UserModel model)
        {
            model.EmailAddress = "1685909098@qq.com";
            User currentUser = mapper.Map<User>(model);
            currentUser.BindingEmail = new Email();
            currentUser.BindingEmail.Code = code;
            currentUser.BindingEmail.Expires = DateTime.Now.AddMinutes(5);
            userRepository.UserSaveChanges(currentUser);
            string mailSubject = $"激活Email,邮箱验证码为{code}";
            string mailBody = $"感谢你的Email绑定......点击<a href='https://localhost:44380/Email/Activate?id={CurrentUserId}&code={code}'进行验证 >";
            ValidEmail(mailSubject, model.EmailAddress, mailBody);
        }

        public UserModel GetUserModelById(int id)
        {
            return mapper.Map<UserModel>(CurrentUser);
        }

        public void UIMapUserSaveChanges(UserModel model)
        {
            User currentUser = mapper.Map<User>(model);
            userRepository.UserSaveChanges(currentUser);
        }
    }
}
