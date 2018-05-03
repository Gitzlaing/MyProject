using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.EntitiesModel;
using MyProject.Common;
using MyProject.Bll;

namespace MyProject.Opportal.Controllers
{
    public class HomeController : Controller
    {
        private OperatorBll bllOperator = new OperatorBll();
        private UserInfoBll bllUserinfo = new UserInfoBll();
        private CompanyInfoBll bllCompanyinfo = new CompanyInfoBll();

        /// <summary>
        ///主页面，显示网站信息概况
        /// </summary>
        /// <returns></returns>
        public ActionResult Main()
        {
            ViewBag.UserRecords = bllUserinfo.GetRecords();
            ViewBag.CompanyRecords = bllCompanyinfo.GetRecords();
            Operator model = (Operator)Session[Key.Current_Operator];
            if (model != null)
            {
                ViewBag.UserName = model.OperatName;
            }
            return View(model);
        }
    }
}