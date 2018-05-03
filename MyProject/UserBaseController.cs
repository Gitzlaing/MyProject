using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Common;
using MyProject.EntitiesModel;
using MyProject.Bll;
namespace MyProject
{
    public class UserBaseController : Controller
    {
        EFDbContext db = BaseBll.db;
        protected override void OnActionExecuting(ActionExecutingContext filterContext) 
        {
            base.OnActionExecuting(filterContext);
            if (Session[Key.Current_User] == null)       //检查session 
            {
                HttpCookie userCookie = Response.Cookies["UserId"];        //检查cookie
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
                if (int.TryParse(userId, out id))
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
                        Session[Key.Current_User] = model;
                        filterContext.Controller.ViewBag.UserName = model.Username;
                        filterContext.Controller.ViewBag.LoginType = "User" ;
                    }
            }
            else
            {
                UserInfo ui = (UserInfo)Session[Key.Current_User];
                filterContext.Controller.ViewBag.UserName = ui.Username;
                filterContext.Controller.ViewBag.LoginType = "User";
            }
        }

        //private void RedirectToLoginAction()
        //{
        //    Response.Write("<script>alert('你还未登录');location.href='/Login/Index'</script>");
        //    Response.End();
        //}
    }
}