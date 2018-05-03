using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MyProject.Common
{
    public class ScriptHelper
    {
        /// <summary>
        /// Alert弹窗
        /// </summary>
        /// <param name="msg"></param>
        public static void Alert(string msg)
        {
            string script = "alert('" + msg + "');";
            RegisterScipt(script);
        }

        /// <summary>
        /// Alert弹窗,并跳转
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="url"></param>
        public static void AlertRedirect(string msg, string url)
        { 
            string script = "alert('" + msg + "');location.href='" + url + "'";
            RegisterScipt(script);
        }

        /// <summary>
        /// Alert弹窗，并刷新
        /// </summary>
        public static void AlertRefresh(string msg)
        {
            string script = "alert('" + msg + "');location.href=location.href";
            RegisterScipt(script);
        }

        /// <summary>
        /// Alert弹窗，并回退
        /// </summary>
        /// <param name="msg"></param>
        public static void AlertGoBack(string msg)
        {
           string script = "alert('" + msg + "');history.go(-1);";
            RegisterScipt(script);
        }

        /// <summary>
        /// 浏览器回退
        /// </summary>
        public static void GoBack(int count)
        {
            string script = "history.go(-" + count + ");";
            RegisterScipt(script);
        }


        /// <summary>
        /// 公用函数
        /// </summary>
        /// <param name="script"></param>
        public static void RegisterScipt(string script)
        {
                HttpContext.Current.Response.Write("<script>" + script + "</script>");
        }
    }
}
