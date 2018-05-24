using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Bll;
using MyProject.EntitiesModel;
using MyProject.Common;
using MyProject.MyAttributes;
namespace MyProject.Areas.Company.Controllers
{
    [CompanyUserCheck]
    public class ResumeController : Controller
    {
        /// <summary>
        /// 返回用户简历
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public ActionResult UserResume(int uid = 0)
        {
            UserInfoBll bllUser = new UserInfoBll();
            UserInfo model = bllUser.GetModel(uid);
            if (model != null)
            {
                ViewBag.WorkExp = model.WorkExperience.ToList();
                ViewBag.ProjectExp = model.ProjectExperience.ToList();
            }
            return View(model);
        }

        /// <summary>
        /// 拒绝简历
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
       [HttpPost]
        public void RefuseResume(int uid = 0,int jobId=0)
        {
            ApplyJobBll applyBll = new ApplyJobBll();
            if (applyBll.Refuse(uid, ViewBag.CompanyId,jobId))
            {
                AjaxHelps.WriteSucessJson("删除成功");
            }
            else
            {
                AjaxHelps.WriteErrorJson("删除失败");
            }
        }
    }
}