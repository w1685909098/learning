using Entities;
using EntityFrameworkCoreSQL.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            UserRepository userRepository = new UserRepository();
            //userRepository.Database.EnsureCreated();//创建
            //userRepository.Database.EnsureDeleted();//删除
            #region users添加user
            //userRepository.Add<User>(new User("AA111","AA1111@") { Name="AA1",Password="AA1111@"});
            //userRepository.Users.AddRange (new List<User>
            //{ 
            //    new User("AA222","AA2222@"),
            //    new User("AA333","AA3233@")
            //});
            #endregion
            //userRepository.SaveChanges();
            #region 通过id找到对应user的name
            //Console.WriteLine(userRepository.Users.Find(2).Name);
            //Console.WriteLine(userRepository.Find<User>(5).Name);
            #endregion
            #region 通过id找到user并修改其name,保存
            userRepository.Find<User>(6).Name = "zz";
            userRepository.SaveChanges();
            #endregion
            #region 不加载User对象，仅凭其Id用一句Update SQL语句完成上题
            User user = new User { Id = 5 };
             userRepository.Attach<User>( user);
            user.Name = "tt";
            userRepository.SaveChanges();
            #endregion
            #region 删除该Id用户
            userRepository.Remove<User>(userRepository.Find<User>(1));
            userRepository.SaveChanges();
            #endregion
            #region 事务的开启
            using (IDbContextTransaction  Transaction= userRepository.Database.BeginTransaction())
            {
                try
                {
                    Transaction.Commit();
                }
                catch (Exception)
                {
                    Transaction.Rollback();
                    throw new  Exception();
                }
                #endregion
            }
        }
    }
}
