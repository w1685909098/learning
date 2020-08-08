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
        UserModel GetUserModelByName(string name);
        void ValidEmail(string address);
        bool BindEmail(int userId, string code);
    }
}
