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

namespace ProdService
{
    public class RegisterService : BaseService, IRegisterService
    {
        public IndexModel GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public int GetRegisterId(IndexModel model)
        {
            UserRepository userRepository = new UserRepository();
            if (userRepository.GetUserByName(model.UserName) != null)
            {
                //用户名已存在
                return 0;
            }
            User inviter = userRepository.GetUserByName(model.Inviter.UserName);
            if (inviter == null)
            {
                //邀请人不存在
                return 0;
            }

            if (inviter.InvitingCode != model.Inviter.InvitingCode)
            {
                //邀请人对应的邀请码不正确
                return 0;
            }
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
            register.Register(register, inviter);
            userRepository.Add(register);
            return register.Id;
        }
    }
}
