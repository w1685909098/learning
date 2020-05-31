﻿using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace ADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //SqlConnection connection = new SqlConnection();
            //connection.Open();
            //connection.Close();
            //String read = Console.ReadLine();
            string DatabasePath = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=17bang;Integrated Security=True;";
            using (DbConnection connection=new SqlConnection(DatabasePath)) //创建一个数据库连接对象
            {
                connection.Open();//打开数据库连接
                #region 参数化查询
                //DbCommand command = new SqlCommand(
                //    $"SELECT * FROM [USER] WHERE userNAME=@Id"
                //    );
                //command.Connection = connection;
                //DbParameter StuParameter = new SqlParameter("@Id", read);
                //command.Parameters.Add(StuParameter);
                //DbDataReader reader= command.ExecuteReader();
                //while (reader.Read())
                //{
                //    Console.WriteLine(reader[0]);
                //}
                #endregion
                #region 存储过程
                //DbCommand command = new SqlCommand();
                //command.CommandText="dbo.ZXC";
                //command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.Add(new SqlParameter("@int",2));
                //DbParameter parameter = new SqlParameter("@out", SqlDbType.Int)
                //{
                //    Direction = ParameterDirection.Output
                //};
                //command.Parameters.Add(parameter);
                //command.Connection = connection;
                //command.ExecuteNonQuery();
                #endregion
                #region 非查询命令
                //DbCommand command = new SqlCommand(
                //    //$"INSERT [USER] VALUES(N'练习',N'练习',1)"
                //    $"UPDATE [USER] SET PASSWORD=4 WHERE ID=4"
                //    );//创建命令
                //command.Connection = connection;//需要指明命令行操作对应的数据库
                //command.ExecuteNonQuery();//非查询操作  增删改
                #endregion
                #region 查询命令Scalar
                //DbCommand command = new SqlCommand($"SELECT * FROM [USER]");
                //command.Connection = connection;
                //object Scalar=command.ExecuteScalar(); //返回的为第一列的第一行数据
                //Console.WriteLine($"ExecuteScalar:{Scalar}");
                #endregion
                #region 查询命令Reader
                //command = new SqlCommand($"SELECT * FROM [USER]");
                //command.Connection = connection;
                //DbDataReader reader = command.ExecuteReader();
                ////object DataReader = command.ExecuteReader();
                ////Console.WriteLine($"ExecuteReader:{DataReader}");
                //Console.WriteLine(reader.Read());
                //Console.WriteLine(reader.HasRows);
                //while (reader.Read())
                //{
                //    Console.WriteLine(reader["username"]);
                //}
                #endregion
            }

            string TrainPath = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=training;Integrated Security=True;";
            using (SqlConnection dbConnection=new SqlConnection(TrainPath))
            {
                dbConnection.Open();
                DbCommand dbCommand = new SqlCommand();
                //dbCommand.CommandText = "dbo.ZXC";
                //dbCommand.CommandType = CommandType.StoredProcedure;
                //dbCommand.Parameters.Add(new SqlParameter("@int",5));
                //SqlParameter sqlParameter = new SqlParameter("@out",SqlDbType.Int)
                //{
                //    Direction = ParameterDirection.Output
                //};
                //dbCommand.Parameters.Add(sqlParameter);
                //dbCommand.Connection = dbConnection;
                //dbCommand.ExecuteNonQuery();
                //Console.WriteLine(sqlParameter.Value);

                using (SqlTransaction  transaction=dbConnection.BeginTransaction())
                {
                    try
                    {
                        dbCommand.Transaction = transaction;
                        dbCommand.CommandText="UPDATE TSCORE SET SCORE -=0";
                        dbCommand.Connection = dbConnection;
                        dbCommand.ExecuteNonQuery();

                        dbCommand.CommandText = "UPDATE TSCORE SET SCORE -=0";
                        dbCommand.Connection = dbConnection;
                        dbCommand.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

            }


            DataTable dtRegister = new DataTable("Register");
            dtRegister.Columns.Add("Id",typeof(Int32));
            dtRegister.Columns.Add("Name", typeof(string));
            dtRegister.Columns.Add("Password", typeof(string));
            dtRegister.Columns.Add("InvistedBy", typeof(Int32));
            dtRegister.Rows.Add(1,"111","111",1);

            DataSet dt17bang = new DataSet("17bang");
            dt17bang.Tables.Add(dtRegister);
            dt17bang.Tables.Add(new DataTable("Problem"));

        }
    }
}
