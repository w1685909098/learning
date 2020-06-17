using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _17bangMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute
                (
                name: "ArticleSingle",
                url: "Article/{Id}",
                defaults: new { controller = "Article", action = "Single" }
                //constraints: new { Id = @"\d*" }
                );
            //routes.MapRoute
            //    (
            //    name:"ArticleIndex",
            //    url:"Article",
            //    defaults:new{controller="Article",action="Index" }
            //    //constraints:"",
            //    );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
