﻿using AutoMapper;
using Entity;
using Microsoft.SqlServer.Server;
using Repository;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ViewModel.Keyword;
using ViewModel.Register;

namespace ProdService
{
    public class BaseService : IBaseService
    {
        private static MapperConfiguration _mapperConfiguration;
        protected UserRepository userRepository;
        public BaseService()
        {
            userRepository = new UserRepository(context);
        }
        static BaseService()
        {
            //_mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap(typeof(User),typeof(ViewModel.Register.IndexModel)));
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<User, ViewModel.Register.IndexModel>().ReverseMap();
                #region 注册的映射配置
                cfg.CreateMap<User, ViewModel.Register.UserModel>()  //配置映射     TSource（左）映射到TDestition（右）
                .ForMember(m => m.UserId, opt => opt.MapFrom(u => u.Id))
                .ForMember(m => m.UserName, opt => opt.MapFrom(u => u.Name))  //具体的映射   TDestition（左）   TSource（右）
                .ForMember(m => m.Password, opt => opt.MapFrom(u => u.Password))
                .ForMember(m => m.InviterName, opt => opt.MapFrom(u => u.Inviter.Name))
                .ForMember(m => m.InvitingCode, opt => opt.MapFrom(u => u./*Inviter.*/InvitingCode))
                .ForMember(m => m.ComfirmPassword, opt => opt.Ignore())   //忽略某一属性
                .ForMember(m => m.Captcha, opt => opt.Ignore())   //忽略验证码
                .ForMember(m=>m.EmailAddress,opt=>opt.MapFrom(u=>u.BindingEmail.Address))
                .ForMember(m => m.EmailCode, opt => opt.MapFrom(u => u.BindingEmail.Code))
                //.ForMember(m => m.ExprieTime, opt => opt.MapFrom(u => u.BindingEmail.Expires))
                .ForMember(m => m.EmailIsActivate, opt => opt.MapFrom(u => u.BindingEmail.IsAvtivate))
                //.ForMember(m => m.InputTime, opt => opt.Ignore())    
                .ReverseMap()
                .ForMember(u => u.Id, opt => opt.NullSubstitute(0))   //null值处理
                .ForMember(u => u.InvitingCode, opt => opt.Ignore())
                .ForMember(u=>u.BindingEmail,opt=>opt.MapFrom(m=>m));
                #endregion
                cfg.CreateMap<ViewModel.Register.UserModel, Email>(MemberList.None)
                .ForMember(e=>e.Address,opt=>opt.MapFrom(m=>m.EmailAddress))
                ;
                #region article的映射配置
                cfg.CreateMap<Article, ViewModel.Article.ArticleItemModel>()
                 .ForMember(m => m.PublishTime, opt => opt.MapFrom(a => a.PublishTime))
                 .ForMember(m => m.AuthorName, opt => opt.MapFrom(a => a.Author.Name))
                 .ForMember(m => m.AuthorId, opt => opt.MapFrom(a => a.UserId))
                 .ForMember(m => m.Title, opt => opt.MapFrom(a => a.Title))
                 .ForMember(m => m.Id, opt => opt.MapFrom(a => a.Id))
                 .ForMember(m => m.Body, opt => opt.MapFrom(a => a.Body))
                 .ForMember(m => m.KeywordModels, opt => opt.MapFrom(a => a.Keywords))
                 .ForMember(m => m.CommnetCount, opt => opt.MapFrom(a => a.Commnets.Count))
                 .ForMember(m => m.AgreeCount, opt => opt.MapFrom(a => a.AgreeCount))
                 .ForMember(m => m.DisagreeCount, opt => opt.MapFrom(a => a.DisagreeCount))
              /* .ReverseMap()*/;
                //cfg.CreateMap<User,ViewModel.Article.ArticleItemModel>(MemberList.None)
                //.ForMember(a=> a.AuthorName, opt => opt.MapFrom(u => u.Name));
                #endregion



                cfg.CreateMap<Keyword, ViewModel.Keyword.KeywordModel>();

                #region 个人资料的映射
                cfg.CreateMap<User, ViewModel.Personal.PersonalInformationModel>(MemberList.None)
                .ForMember(m => m.IconPath, opt => opt.MapFrom(u => u.IconPath))
                .ForMember(m => m.UserId, opt => opt.MapFrom(u => u.Id))
                .ForMember(m => m.UserName, opt => opt.MapFrom(u => u.Name))
                .ForMember(m=>m.Password,opt=>opt.MapFrom(u=>u.Password))
                .ForMember(m=>m.InvitingCode,opt=>opt.MapFrom(u=>u.InvitingCode))
                .ForMember(m=>m.InviterId,opt=>opt.MapFrom(u=>u.Inviter.Id))
                .ForMember(m => m.ArticleId, opt => opt.MapFrom(u => u.ArticleId))
                .ReverseMap();
                #endregion

               
                cfg.CreateMap<User, ViewModel.LogOn.LogOnModel>()
                .ForMember(m => m.UserId, opt => opt.MapFrom(u => u.Id))
                .ForMember(m => m.UserName, opt => opt.MapFrom(u => u.Name))
                .ForMember(m => m.Password, opt => opt.MapFrom(u => u.Password))
                .ForMember(m => m.Captcha, opt => opt.Ignore())
                 .ReverseMap()
                 ;
            });
#if DEBUG
            _mapperConfiguration.AssertConfigurationIsValid();
#endif
        }
        protected IMapper mapper
        {
            get
            {
                return _mapperConfiguration.CreateMapper();
            }
        }

        public void CommitTrans()
        {
            SqlDbContext currentContext = (SqlDbContext)HttpContext.Current.Items["context"];
            {
                if (currentContext != null)
                {
                    #region 手动释放资源
                    DbContextTransaction transaction = currentContext.Database.CurrentTransaction;
                    try
                    {
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        //currentContext.Dispose();
                        currentContext = null;
                    }
                    #endregion
                    //currentContext.Database.CurrentTransaction.Commit();

                    #region 自动释放资源
                    //using (DbContextTransaction transaction = currentContext.Database.CurrentTransaction)
                    //{
                    //    try
                    //    {
                    //        currentContext.SaveChanges();
                    //        transaction.Commit();
                    //    }
                    //    catch (Exception)
                    //    {
                    //        transaction.Rollback();
                    //        throw;
                    //    }
                    //}
                    #endregion

                } //else nothing
            }
        }
        public void RollbackTrans()
        {
            using (SqlDbContext currentContext = (SqlDbContext)HttpContext.Current.Items["context"])
            {
                if (currentContext != null)
                {
                    using (DbContextTransaction transaction = currentContext.Database.CurrentTransaction)
                    {
                        transaction.Rollback();
                    }
                } //else nothing
            }
        }
        protected SqlDbContext context
        {
            get
            {
                SqlDbContext currentContext = (SqlDbContext)HttpContext.Current.Items["context"];
                if (currentContext == null)
                {
                    #region 自己的理解  每次 HttpContext.Current.Items["context"]  都为null
                    //currentContext = new SqlDbContext();
                    //currentContext.Database.BeginTransaction();//开启事务
                    //HttpContext.Current.Items["context"] = currentContext;
                    #endregion

                    currentContext = new SqlDbContext();
                    currentContext.Database.BeginTransaction();//开启事务
                    HttpContext.Current.Items["context"] = currentContext;
                } //else nothing
                return currentContext;
            }
        }
        protected int? CurrentUserId
        {
            get
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["user"];
                if (cookie == null)
                {
                    return null;
                }
                //return Convert.ToInt32(HttpContext.Current.Response.Cookies[""].Values[""]);
                string id = cookie.Values["id"];
                string password = cookie.Values["password"];
                User currentUser = userRepository.Find(Convert.ToInt32(id));
                if (currentUser.Password != password)
                {
                    throw new Exception();
                }
                return Convert.ToInt32(id);
            }
        }
        protected User CurrentUser
        {
            get
            {
                if (CurrentUserId == null)
                {
                    return null;
                }
                else
                {
                    return userRepository.Find((int)CurrentUserId);
                }
            }
        }
    }
}

