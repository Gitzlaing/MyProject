using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Common;
using MyProject.EntitiesModel;
namespace MyProject.Opportal.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            if (Session[Key.Current_Operator] != null)
            {
                Operator model = (Operator)Session[Key.Current_Operator];
                filterContext.Controller.ViewBag.UseName = model.OperatName;
                filterContext.Controller.ViewBag.TypeName = "超级管理员";
            }
            else
            {
                RedirectToLogiAaction();
            }

        }

        private void RedirectToLogiAaction()
        {
            Response.Write("<script>alert('你还未登录');location.href='/home/index'</script>");
            Response.End();
        }
    }
}