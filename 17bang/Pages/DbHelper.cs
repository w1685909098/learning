using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages
{
    public class DbHelper
    {
        private string connectionString17bang = @"Data Source = (localdb)\MSSQLLocalDB;
                       Initial Catalog = 17bang;Integrated Security = True;";
        public void Insert(string cmdContext,DbConnection connection)
        {
            using (connection)
            {
                connection.Open();
                DbCommand command = new SqlCommand(cmdContext);
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }
        public void Delete(string cmdContext, DbConnection connection)
        {
            using (connection)
            {
                connection.Open();
                DbCommand command = new SqlCommand(cmdContext);
                command.Connection = connection;
                command.ExecuteNonQuery();
            }

        }
        public void Update(string cmdContext, DbConnection connection)
        {
            using (connection)
            {
                connection.Open();
                DbCommand command = new SqlCommand(cmdContext);
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }
        public void GetBy(string cmdContext, DbConnection connection)
        {
            using (connection)
            {
                connection.Open();
                DbCommand command = new SqlCommand(cmdContext);
                command.Connection = connection;
                command.ExecuteReader();
            }
        }
    }
}
