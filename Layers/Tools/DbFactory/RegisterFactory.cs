using Entity;
using Extension;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DbFactory
{
    internal class RegisterFactory
    {
        private static UserRepository userRepository;
        static RegisterFactory()
        {
            userRepository = new UserRepository(Global.Context);
        }
        internal static User xx, tt;
        public static string password = "1111";
        public static void Create()
        {
            xx = new User
            {
                //Id = 1,
                Name = "xx",
                Password = password.MD5Encrypt(),
                InvitingCode = "1111",
                BindingEmail = new Email()
            };
            tt = new User
            {
                //Id=2,
                Name = "tt",
                Password = password.MD5Encrypt(),
                InvitingCode = RandomString.GetRandomCode(),
                BindingEmail=new Email()
            };
            userRepository.AddUser(xx);
            userRepository.AddUser(tt);
            //userRepository.AddRangeEntities(new List<User> { xx, tt });
        }
    }
}
