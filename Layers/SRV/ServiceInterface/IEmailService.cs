using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Register;

namespace ServiceInterface
{
   public interface IEmailService
    {
        UserModel GetUserModelById(int id);
        UserModel GetUserModelByName(string name);
        void SendEmail(UserModel model);
        bool BindEmail(int userId, string code);
        void UIMapUserSaveChanges(UserModel model);
    }
}
