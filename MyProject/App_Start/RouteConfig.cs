using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}"); //忽略路由 如果请求中带了.axd后缀的则忽略 不会匹配路由 用于访问静态文件
            routes.MapRoute(
               name: "Login",
               url: "Login",
               defaults: new { controller = "Login", action = "Index" }
               );

            routes.MapRoute(
                name: "Register",
                url: "Register/{typeid}",
                defaults: new { controller = "Register", action = "Index" },
                constraints: new { typeid = @"\d" }
            );


            //路由可以注册多个
            //请求的时候，按照先后顺序进行匹配，谁先匹配上就使用哪个路由规则
            routes.MapRoute(
              namespaces: new string[] { "MyProject.Controllers" },
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           //controller = "Home" 设置控制器的默认值
           // UrlParameter.Optional可选参数表示可传可不传
           );


            #region 笔记
            ////如果url中controller有固定值的话 【字面量与正则混写】 student/{action} 在defaults参数中必须指定Controller的值为字面量 student
            //routes.MapRoute(
            //    name: "Route1",
            //    url: "Student/{action}", //字面量与正则写
            //    defaults: new { controller = "Student" }
            //    );

            //routes.MapRoute(
            //    name: "MyRoute",
            //    url: "{controller}/{action}/{myid}/{name}",
            //    defaults: new { controller = "Home", action = "Index" },
            //    constraints: new { myid = @"\d+", name = @"[a-zA-Z]+" },  //参数正则表达式约束
            //    namespaces: new string[] { "MyProject" }
            //    //命名空间 如果在指定的命名空间下找不到Controller与Action 就会在其他命名空间下查找Controller与Action
            //    //如果在指定命名空间下查找控制器类，大大节省了查找时间，效率更高
            //); 
            #endregion




        }
    }
}
