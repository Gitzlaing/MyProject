using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MyProject.Bll;
namespace MyProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 网站启动时触发
        /// </summary>
        protected void Application_Start()
        {
          //  SqlDependency 数据库监听类
           // SqlDependency.Start(ConfigurationManager.ConnectionStrings["EFDbContext"].ConnectionString);

            AreaRegistration.RegisterAllAreas();  //注册区域(包含区域路由)，比全局路由具有优先级
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);//过滤器
            RouteConfig.RegisterRoutes(RouteTable.Routes);//注册路由规则 
            BundleConfig.RegisterBundles(BundleTable.Bundles);//注册脚本
            
            //路由调试 第三方工具  RouteDebug
          //  RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);    //英文版
        }
    }
}
