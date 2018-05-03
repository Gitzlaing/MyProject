using System.Web;
using System.Web.Mvc;
using MyProject.MyAttributes;
namespace MyProject
{
    public class FilterConfig
    {
        /// <summary>
        /// 注册全局过滤器,不管什么url都会执行
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());  //注册异常处理过滤器
            //filters.Add(new UserCheckAttribute());
            //filters.Add(new CompanyUserCheckAttribute());
            //可以注册多个过滤器
            //结果过滤器
        }
    }
}
