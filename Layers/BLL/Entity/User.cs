﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User :BaseEntity
    {
        public User Inviter { get; set; }
        [MaxLength(10)]
        public string Name { get; set; }
        public string Password { get; set; }
        public string InvitingCode { get; set; }
        public int Credit { get; set; }
        public int BMoney { get; set; }
        public void Register(User register )
        {
            register.Credit += 10;
            register.Inviter.Credit += new Random().Next(3) + 2;
        }
    }
}
