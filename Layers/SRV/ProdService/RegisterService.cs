using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Register;
using System.Web.Mvc;
using ServiceInterface;
using AutoMapper;

namespace ProdService
{
    public class RegisterService : BaseService, IRegisterService
    {
      private  UserRepository userRepository  ;
        public RegisterService()
        {
            userRepository = new UserRepository(context);
        }

        public IndexModel GetByName(string name)
        {
            User user = userRepository.GetUserByName(name);
            return mapper.Map<IndexModel>(user);
        }

        public int GetRegisterId(IndexModel model)
        {
            User inviter = userRepository.GetUserByName(model.InviterName);
            User register = mapper.Map<User>(model);
            //register = mapper.Map<IndexModel, User>(model, register);//全部替换  保留Id
            #region 没有AutoMap  手动赋值
            //User register = new User
            //{
            //    UserName = model.UserName,
            //    Password = model.Password,
            //    Inviter = inviter
            //};
            #endregion
            register.Inviter = inviter;
            register.Register(register);
            return userRepository.Add(register);
            //return register.Id;
        }
    }
}
