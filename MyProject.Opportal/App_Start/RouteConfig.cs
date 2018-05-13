using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyProject.Opportal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //统一 一个菜单项的url格式
            routes.MapRoute(
             name: "List",
             url: "{controller}/List/{action}/{id}",
             defaults: new { controller = "Company", action = "Index", id = UrlParameter.Optional }
             );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

           // routes.MapRoute(
           //    name: "Default2",
           //    url: "{controller}/{action}/{id}/{id2}",
           //    defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
           //);
        }
    }
}
