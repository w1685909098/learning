using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Register;
using System.Web.Mvc;

namespace ProdService
{
    public class RegisterService
    {
        public void Register(IndexModel model)
        {
            UserRepository userRepository = new UserRepository();
            User inviter = userRepository.GetUserByName(model.Inviter.UserName);
            if (inviter == null)
            {
                return;
            }
           
            if (inviter.InvitingCode!=model.Inviter.InvitingCode)
            {
                return;
            }
            User register = new User
            {
                UserName = model.UserName,
                Password = model.Password,
                Inviter = inviter
            };
            register.Register(register, inviter);
            userRepository.Add(register);
        }
    }
}
