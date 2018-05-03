using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Common;
using MyProject.EntitiesModel;
using MyProject.Bll;

namespace MyProject.MyAttributes
{
    /// <summary>
    /// 检查求职用户登陆、Session、Cookies
    /// </summary>
    public class CompanyUserCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (HttpContext.Current.Session[Key.Current_Company] == null)       //检查session
            { 
                HttpCookie userCookie = HttpContext.Current.Request.Cookies["CompanyId"];        //检查cookie
      
                if (userCookie == null)
                {
                    RedirectToLogiAaction();
                    return;
                }
                string value = userCookie.Value;
                if (string.IsNullOrWhiteSpace(value))
                {
                    RedirectToLogiAaction();
                    return;
                }
                string userId = CryptoHelper.TripleDES_Decrypt(value, Key.TRIPLEDES_KEY);  //cookies解密
                int id = 0;
                if (!int.TryParse(userId, out id))
                {
                    RedirectToLogiAaction();
                    return;
                }
                    CompanyInfo model = BaseBll.db.CompanyInfo.Where(o => o.CompanyId == id).FirstOrDefault();
                    if (model == null)
                    {
                        RedirectToLogiAaction();
                        return;
                    }
                    else
                    {
                        HttpContext.Current.Session[Key.Current_Company] = model;
                        filterContext.Controller.ViewBag.UserName = model.Username;
                        filterContext.Controller.ViewBag.LoginType = "Company";
                    }
            }
            else
            {
                CompanyInfo ci = (CompanyInfo)HttpContext.Current.Session[Key.Current_Company];
                filterContext.Controller.ViewBag.UserName = ci.Username;
                filterContext.Controller.ViewBag.LoginType = "Company";
            }
        }

        /// <summary>
        /// 重定向到登陆界面
        /// </summary>
        private void RedirectToLogiAaction()
        {
           HttpContext.Current.Response.Write("<script>alert('你还未登录');location.href='/login/index'</script>");
            HttpContext.Current.Response.End();
        }
    }
}