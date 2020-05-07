using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Pages.ViewModel;

namespace _17bang.Pages.Repository
{
    public class UserRepository
    {
        private static int _LastedId;
        private static IList<UserModel> _users;
        static UserRepository()
        {
            _users = new List<UserModel> { };
        }
        public int UserSave(UserModel model)
        {
            _LastedId++;
            model.Id = _LastedId;
            _users.Add(model);
            return _LastedId;
        }
        public UserModel GetUserByName(string name)
        {
            return _users.Where(u => u.Name == name).SingleOrDefault();
        }
    }
}
