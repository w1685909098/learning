using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ArticleSingle",
                url: "{Article}/{id}",
                defaults: new { controller = "Article", action = "Single"/*, id = UrlParameter.Optional */},
                constraints: new { id = @"\d*" }
                );

            routes.MapRoute(
                name: "ArticlePaged",
                url: "{Article}/Paged-{id}",
                defaults: new { controller = "Article", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
