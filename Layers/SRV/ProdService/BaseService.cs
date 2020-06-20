using AutoMapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                cfg.CreateMap<User, ViewModel.Register.IndexModel>()  //配置映射     TSource（左）映射到TDestition（右）
                .ForMember(i => i.UserName, opt => opt.MapFrom(u => u.UserName))  //具体的映射   TDestition（左）   TSource（右）
                .ForMember(i => i.ComfirmPassword, opt => opt.Ignore())   //忽略某一属性
                .ReverseMap()
                .ForMember(i => i.Id, opt => opt.NullSubstitute(0));   //null值处理

                cfg.CreateMap<Article, ViewModel.Article.ArticleItemModel>()
                .ForMember(i=>i.CommnetCount,opt=>opt.MapFrom(a=>a.Commnets.Count));
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
    }
}

