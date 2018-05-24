using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.MyAttributes;
using MyProject.EntitiesModel;
using MyProject.Bll;
using MyProject.Common;
namespace MyProject.Areas.Company.Controllers
{
    [CompanyUserCheck]
    public class EditController : Controller
    {
        CompanyInfoBll bllCompany = new CompanyInfoBll();
        // GET: Company/Edit
        public ActionResult Index()
        {
            CompanyInfo currentModel = (CompanyInfo)Session[Key.Current_Company];
            return View(currentModel);
        }



        /// <summary>
        /// 账号信息设置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateInfo(CompanyInfo model)
        {
            CompanyInfo currentModel = (CompanyInfo)Session[Key.Current_Company];
            if (model != null)
            {
                if (bllCompany.UpdateCompanyInfo(currentModel.CompanyId, model))
                {
                    ViewBag.Msg = "修改成功";
                    currentModel = (CompanyInfo)Session[Key.Current_Company];
                }
                else
                {
                    ViewBag.Msg = "修改失败";
                }
            }
            return View("Index", currentModel);
        }

        /// <summary>
        /// 简历管理,获取未处理的简历
        /// </summary>
        /// <returns></returns>
        public ActionResult Resume()
        {
            ApplyJobBll applyBll = new ApplyJobBll();
            List<ApplyJob> userResumeList = applyBll.GetCompanyList(ViewBag.CompanyId,0);
            return View(userResumeList);
        }

    }
}