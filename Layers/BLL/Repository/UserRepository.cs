﻿using Entity;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository
    {
        private IList<User> _user;
        public UserRepository()
        {
            _user = new List<User>() 
            { 
                new User
                {
                    UserName="xx",
                    InvitingCode="1234"
                },
                 new User
                {
                    UserName="tt",
                    InvitingCode="1234"
                }

            };
        }
        public User GetUserByName(string name)
        {
            return _user.Where(u => u.UserName == name).SingleOrDefault();
        }
        public int Add(User user)
        {
            _user.Add(user);
            return user.Id;
        }
    }
}