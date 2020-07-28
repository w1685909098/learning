using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.LogOn;

namespace ServiceInterface
{
    public  interface ILogOnService
    {
        LogOnModel GetLogOnModelByName(string name);
    }
}
