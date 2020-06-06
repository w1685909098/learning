using System;
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
            string connectionStringUser = @"Data Source=(localdb)\MSSQLLocalDB;
                   Initial Catalog=17bang;Integrated Security=True;";
            using (DbConnection connection = new SqlConnection(connectionStringUser))
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
            string connectionStringUser = @"Data Source=(localdb)\MSSQLLocalDB;
                                    Initial Catalog=17bang;Integrated Security=True;";
            using (DbConnection connection = new SqlConnection(connectionStringUser))
            {
                IList<UserModel> _usersFromDataBase = new List<UserModel>();
                connection.Open();
                DbCommand command = new SqlCommand(
                    //$"SELECT * FROM [USER] WHERE USERNAME=@name"
                    $"SELECT * FROM [USER] "

                    );
                //DbParameter pName = new SqlParameter("@name", name);
                //command.Parameters.Add(pName);
                command.Connection = connection;
                DbDataReader reader = command.ExecuteReader();
                if (!reader.HasRows)
                {
                    return null; ;
                } 
                while (reader.Read())
                {
                    UserModel userModel = new UserModel();
                    if (reader["UserName"]==DBNull.Value)
                    {
                        userModel.Name = "";
                    }
                    else if(reader["Password"] == DBNull.Value)
                    {
                        userModel.Password = "";
                    }
                    else
                    {
                        userModel.Id=(int)reader["Id"];
                        userModel.Name = (string)reader["UserName"];
                        userModel.Password = (string)reader["Password"];
                        _usersFromDataBase.Add(userModel);
                    }
                    //_usersFromDataBase.Add(userModel);
                    //_users = _usersFromDataBase;
                };
                _users = _usersFromDataBase;
                return _users.Where(u => u.Name == name).SingleOrDefault();
                //return userModel;
            }
            #region 简单登录  只有连接一次只返回一个对象
            //using (DbConnection connection = new SqlConnection(connectionString))
            //{
            //    UserModel userModel = new UserModel();
            //    IList<UserModel> _usersFromDataBase = new List<UserModel>();
            //    connection.Open();
            //    DbCommand command = new SqlCommand(
            //        $"SELECT * FROM [USER] WHERE USERNAME=@name"
            //        //$"SELECT * FROM [USER] "

            //        );
            //    DbParameter pName = new SqlParameter("@name", name);
            //    command.Parameters.Add(pName);
            //    command.Connection = connection;
            //    DbDataReader reader = command.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        //UserModel userModel = new UserModel();
            //        if (reader["UserName"] == DBNull.Value)
            //        {
            //            userModel.Name = null;
            //        }
            //        else if (reader["Password"] == DBNull.Value)
            //        {
            //            userModel.Password = null;
            //        }
            //        else
            //        {
            //            userModel.Id = (int)reader["Id"];
            //            userModel.Name = (string)reader["UserName"];
            //            userModel.Password = (string)reader["Password"];
            //        }
            //        //_usersFromDataBase.Add(userModel);
            //        //_users = _usersFromDataBase;
            //    };
            //    //return _users.Where(u => u.Name == name).SingleOrDefault();
            //    return userModel;
            //}
            #endregion
            #region MyRegion   _user.Add  打开一次连接就会添加一次找到数据库的对象  导致single失效
            //using (DbConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    DbCommand command = new SqlCommand(
            //        //$"SELECT * FROM [USER] WHERE USERNAME=@name"
            //        $"SELECT * FROM [USER] "

            //        );
            //    //DbParameter pName = new SqlParameter("@name", name);
            //    //command.Parameters.Add(pName);
            //    command.Connection = connection;
            //    DbDataReader reader = command.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        UserModel userModel = new UserModel();
            //        if (reader["UserName"] == DBNull.Value)
            //        {
            //            userModel.Name = null;
            //        }
            //        else if (reader["Password"] == DBNull.Value)
            //        {
            //            userModel.Password = null;
            //        }
            //        else
            //        {
            //            userModel.Id = (int)reader["Id"];
            //            userModel.Name = (string)reader["UserName"];
            //            userModel.Password = (string)reader["Password"];
            //        }
            //        _users.Add(userModel);
            //    };
            //    return _users.Where(u => u.Name == name).SingleOrDefault();
            //    //return userModel;
            //}
            #endregion
        }
    }
}