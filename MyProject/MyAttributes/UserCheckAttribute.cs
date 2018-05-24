using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Common;
using MyProject.EntitiesModel;
using MyProject.Bll;
using MyProject.Controllers;

namespace MyProject.MyAttributes
{
    /// <summary>
    /// 检查普通用户登陆、Session、Cookies
    /// </summary>
    public class UserCheckAttribute : ActionFilterAttribute
    {
        EFDbContext db = BaseBll.db;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (HttpContext.Current.Session[Key.Current_User] == null)       //检查session
            {
                HttpCookie userCookie = HttpContext.Current.Request.Cookies["UserId"];        //检查cookie
                UserController ba = new UserController();
                if (userCookie == null)
                {
                    return;
                }
                string value = userCookie.Value;
                if (string.IsNullOrWhiteSpace(value))
                {
                    return;
                }
                string userId = CryptoHelper.TripleDES_Decrypt(value, Key.TRIPLEDES_KEY);
                int id = 0;
                if (!int.TryParse(userId, out id))
                {
                    return;
                }
                UserInfo model = db.UserInfo.Where(o => o.Uid == id).FirstOrDefault();
                if (model == null)
                {
                    return;
                }
                else
                {
                    HttpContext.Current.Session[Key.Current_User] = model;
                    filterContext.Controller.ViewBag.UserName = model.Username;
                    filterContext.Controller.ViewBag.Uid = model.Uid;
                    filterContext.Controller.ViewBag.Name = model.Name;
                    filterContext.Controller.ViewBag.LoginType = "User";
                }
            }
            else
            {
                UserInfo ui = (UserInfo)HttpContext.Current.Session[Key.Current_User];
                filterContext.Controller.ViewBag.UserName = ui.Username;
                filterContext.Controller.ViewBag.Uid = ui.Uid;
                filterContext.Controller.ViewBag.Name = ui.Name;
                filterContext.Controller.ViewBag.LoginType = "User";

            }
        }
    }
}