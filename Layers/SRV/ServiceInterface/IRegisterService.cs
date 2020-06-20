using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Register;

namespace ServiceInterface
{
    public interface IRegisterService
    {
        IndexModel GetByName(string name);
        int GetRegisterId(IndexModel model);
    }
}
