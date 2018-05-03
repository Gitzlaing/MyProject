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
    public class CompanyBaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (Session[Key.Current_Company] == null)       //检查session
            {
                HttpCookie userCookie = Response.Cookies["CompanyId"];        //检查cookie
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
                string userId = CryptoHelper.TripleDES_Decrypt(value, Key.TRIPLEDES_KEY);
                int id = 0;
                if (int.TryParse(userId, out id))
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
                        Session[Key.Current_Company] = model;
                        filterContext.Controller.ViewBag.UserName = model.Username;
                        filterContext.Controller.ViewBag.LoginType = "Company";
                    }
            }
            else
            {
                CompanyInfo ci = (CompanyInfo)Session[Key.Current_Company];
                filterContext.Controller.ViewBag.UserName = ci.Username;
                filterContext.Controller.ViewBag.LoginType = "Company";
            }
        }

        private void RedirectToLogiAaction()
        {
            Response.Write("<script>alert('你还未登录');location.href='/login/index'</script>");
            Response.End();
        }
    }
}