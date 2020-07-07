using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository:BaseRepository<User>
    {
        //private IList<User> _user;
        //public UserRepository()
        //{

        //}
        public UserRepository(DbContext context):base(context)
        {
            //_user = new List<User>() 
            //{ 
            //    new User
            //    {
            //        UserName="xx",
            //        InvitingCode="1234"
            //    },
            //     new User
            //    {
            //        UserName="tt",
            //        InvitingCode="1234"
            //    }
            //};
        }
        public User GetUserByName(string name)
        {
            return Entities.Where(u => u.Name == name).SingleOrDefault();
        }
        //public int Add(User user)
        //{
        //    _user.Add(user);
        //    return user.Id;
        //}
        public int Add(User user)
        {
            Entities.Add(user);
            context.SaveChanges();
            return user.Id;
        }
    }
}
