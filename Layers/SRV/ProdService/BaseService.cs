﻿using AutoMapper;
using Entity;
using Microsoft.SqlServer.Server;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ViewModel.Keyword;

namespace ProdService
{
    public class BaseService
    {
        private static MapperConfiguration _mapperConfiguration;
        static BaseService()
        {
            //_mapperConfiguration = new MapperConfiguration(cfg => cfg.CreateMap(typeof(User),typeof(ViewModel.Register.IndexModel)));
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<User, ViewModel.Register.IndexModel>().ReverseMap();
                cfg.CreateMap<User, ViewModel.Register.UserModel>()  //配置映射     TSource（左）映射到TDestition（右）
                .ForMember(i => i.UserName, opt => opt.MapFrom(u => u.Name))  //具体的映射   TDestition（左）   TSource（右）
                .ForMember(i => i.InviterName, opt => opt.MapFrom(u => u.Inviter.Name))
                .ForMember(i => i.InvitingCode, opt => opt.MapFrom(u => u./*Inviter.*/InvitingCode))
                .ForMember(i => i.ComfirmPassword, opt => opt.Ignore())   //忽略某一属性
                .ReverseMap()
                .ForMember(u => u.Id, opt => opt.NullSubstitute(0))   //null值处理
                .ForMember(u=>u.InvitingCode,opt=>opt.Ignore());

                cfg.CreateMap<Article, ViewModel.Article.ArticleItemModel>()
                 .ForMember(i => i.PublishTime, opt => opt.MapFrom(a => a.PublishTime))
                 .ForMember(i => i.AuthorName, opt => opt.MapFrom(a => a.Author.Name))
                 .ForMember(i => i.AuthorId, opt => opt.MapFrom(a => a.Author.Id))
                 .ForMember(i => i.Title, opt => opt.MapFrom(a => a.Title))
                 .ForMember(i => i.Id, opt => opt.MapFrom(a => a.Id))
                 .ForMember(i => i.Body, opt => opt.MapFrom(a => a.Body))
                 .ForMember(i => i.Keywords, opt => opt.MapFrom(a => a.Keywords))
                .ForMember(i => i.CommnetCount, opt => opt.MapFrom(a => a.Commnets.Count))
               .ForMember(i => i.AgreeCount, opt => opt.MapFrom(a => a.AgreeCount))
               .ForMember(i => i.DisagreeCount, opt => opt.MapFrom(a => a.DisagreeCount))
               /* .ReverseMap()*/;
                cfg.CreateMap<Keyword, ViewModel.Keyword.KeywordModel>();
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

        protected SqlDbContext context
        {
            get
            {
                SqlDbContext context = (SqlDbContext)HttpContext.Current.Items["context"];
                if (context==null)
                {
                     context= new SqlDbContext();
                }
                return context ;
            }
        }   
        protected int? CurrentUserId
        {
            get
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["user"];
                if (cookie==null)
                {
                    return null;
                }
                //return Convert.ToInt32(HttpContext.Current.Response.Cookies[""].Values[""]);
                string id = cookie.Values["id"];
                string password = cookie.Values["password"];
                UserRepository userRepository = new UserRepository(context);
                User currentUser = userRepository.Find(Convert.ToInt32(id));
                if (currentUser.Password!=password)
                {
                    throw new Exception();
                }
                return Convert.ToInt32(id);

            }

        }
    }
}

