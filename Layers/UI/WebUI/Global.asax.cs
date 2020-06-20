using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ContainerBuilder builder = new ContainerBuilder(); //生成builder
            builder.RegisterControllers(typeof(MvcApplication).Assembly);  //注册controller
            builder.RegisterFilterProvider();                  //注册filter

            builder.RegisterType<ProdService.RegisterService>().As<ServiceInterface.IRegisterService>();   //单个类注册
            builder.RegisterAssemblyTypes(typeof(ProdService.RegisterService).Assembly).AsImplementedInterfaces();   //项目集合注册


            IContainer container= builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
