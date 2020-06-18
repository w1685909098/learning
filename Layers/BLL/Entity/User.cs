using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User
    {
        public User Inviter { get; set; }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string InvitingCode { get; set; }
        public int Credit { get; set; }
        public int BMoney { get; set; }
        public void Register(User register,User inviter)
        {
            register.Credit += 10;
            inviter.Credit += new Random().Next(3) + 2;
        }
    }
}
