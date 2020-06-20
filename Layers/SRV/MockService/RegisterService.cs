using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Register;

namespace MockService
{
    public class RegisterService : IRegisterService
    {
        public IndexModel GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public int GetRegisterId(IndexModel model)
        {
            throw new NotImplementedException();
        }
    }
}
