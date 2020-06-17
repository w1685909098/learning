using Entity;
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
        public User GetUserByName(string name)
        {
            return _user.Where(u => u.UserName == name).SingleOrDefault();
        }
    }
}
