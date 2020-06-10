using EntityFrameworkSQL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            UserRepository repository = new UserRepository();
            repository.Database.CreateIfNotExists();

        }
    }
}
