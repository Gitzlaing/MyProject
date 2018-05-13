using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.MyAttributes;
using MyProject.EntitiesModel;
using MyProject.Common;
using MyProject.Bll;

namespace MyProject.Areas.Company.Controllers
{
    [CompanyUserCheck]
    public class HomeController : Controller
    {
        // GET: Company/Home
        public ActionResult Index()
        {
            CompanyInfo model = (CompanyInfo)Session[Key.Current_Company];
            ViewBag.CompanyName = model.CompanyName;
            return View(model);
        }

        public ActionResult Status()
        {
            CompanyInfo model = (CompanyInfo)Session[Key.Current_Company];
            Session[Key.Current_Company] = BaseBll.db.CompanyInfo.Where(o => o.CompanyId == model.CompanyId).FirstOrDefault();
            model = (CompanyInfo)Session[Key.Current_Company];
            ViewBag.CompanyStatus = model.IsIdentify;
            return View(model);
        }

        [HttpPost]
        public JsonResult GetIdentityStauts(int companyId)
        {
          bool isIdentity =  BaseBll.db.CompanyInfo.Where(o => o.CompanyId == companyId).Select(o => o.IsIdentify).FirstOrDefault();

            return Json(new { isIdentity = isIdentity }, JsonRequestBehavior.AllowGet);
        }

        #region Remote验证公司用户名是否重复Action
        /// <summary>
        /// Remote验证公司用户名是否重复Action
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        public ActionResult CheckUsername(string Username)
        {
            CompanyInfo ci = BaseBll.db.CompanyInfo.Where(o => o.Username == Username).FirstOrDefault();
            if (ci == null)
            {
                return Content("true");
            }
            else
            {
                return Content("false");
            }
        }
        #endregion
    }
}