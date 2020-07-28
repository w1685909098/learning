using Entity;
using Repository;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.LogOn;

namespace ProdService
{
   public  class LogOnService:BaseService,ILogOnService
    {
        private UserRepository _userRepository;
        public LogOnService()
        {
            _userRepository = new UserRepository(context);
        }
        public LogOnModel GetLogOnModelByName(string name)
        {
            User user = _userRepository.GetUserByName(name);
            return mapper.Map<LogOnModel>(user);
        }
    }
}
