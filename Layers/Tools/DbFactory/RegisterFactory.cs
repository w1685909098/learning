using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DbFactory
{
   internal class RegisterFactory
    {
        internal static User xx, tt;
        public static string password = "1234";
        public static void Create()
        {
            xx = new User
            {
                UserName = "xx",
                Password = password
            };
            tt = new User
            {
                UserName = "tt",
                Password = password
            };
            new UserRepository().Add(xx);
        }
    }
}
