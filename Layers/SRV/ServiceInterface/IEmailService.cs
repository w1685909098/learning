using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterface
{
   public interface IEmailService
    {
        void ValidEmail(string address);
        bool BindEmail(int userId, string code);
    }
}
