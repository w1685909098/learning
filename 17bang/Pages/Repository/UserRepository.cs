﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Pages.ViewModel;

namespace _17bang.Pages.Repository
{

    public class UserRepository
    {
        //string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
        //                            Initial Catalog=17bang;Integrated Security=True;";
        //       using(DbConnection connection = new SqlConnection())
        //{

        //}
        private static int _LastedId;
        private static IList<UserModel> _users;
        static UserRepository()
        {
            _users = new List<UserModel> { };
        }
        public int UserSave(UserModel model)
        {
            #region 无真实SQL代码
            //_LastedId++;
            //model.Id = _LastedId;
            //_users.Add(model);
            //return _LastedId;
            #endregion
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                    Initial Catalog=17bang;Integrated Security=True;";
            using (DbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DbCommand command = new SqlCommand(
                    $"INSERT [USER](USERNAME,PASSWORD) VALUES(N'{model.Name}',N'{model.Password}')"
                    );
                command.Connection = connection;
                _LastedId = command.ExecuteNonQuery();
                return _LastedId;
            }

        }
        public UserModel GetUserByName(string name)
        {
            #region 无真实SQL数据
            //return _users.Where(u => u.Name == name).SingleOrDefault();
            #endregion
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                    Initial Catalog=17bang;Integrated Security=True;";
            using (DbConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DbCommand command = new SqlCommand(
                    $"SELECT * FROM [USER] WHERE USERNAME=@name"
                    );
                DbParameter pName = new SqlParameter("@name", name);
                command.Parameters.Add(pName);
                command.Connection = connection;
                DbDataReader reader = command.ExecuteReader();
                UserModel userModel = new UserModel();
                while (reader.Read())
                {
                    userModel.Name = (string)reader["UserName"];
                    userModel.Password = (string)reader["Password"];
                };
                return userModel;
            }
        }
    }
}