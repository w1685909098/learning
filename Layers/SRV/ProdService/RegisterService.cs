﻿using Entity;
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
using Extension;

namespace ProdService
{
    public class RegisterService : BaseService, IRegisterService
    {
        //private UserRepository userRepository;
        //public RegisterService()
        //{
        //    userRepository = new UserRepository(context);
        //}

        public UserModel GetByName(string name)
        {
            User user = userRepository.GetUserByName(name);
            return mapper.Map<UserModel>(user);
        }

        public int GetRegisterId(UserModel model)
        {
            model.Password = model.Password.MD5Encrypt();
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
            //register.Register(register);  //实例方法
            //User.Register();  //静态方法
            register.Register();
            model.UserId= userRepository.AddUser(register);
            return (int)model.UserId;
            //return register.Id;
        }
    }
}
