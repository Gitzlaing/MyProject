using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Bll;
using MyProject.MyAttributes;
using MyProject.Common;
using MyProject.EntitiesModel;

namespace MyProject.Areas.User.Controllers
{
    [UserCheck]
    public class JobController : Controller
    {
        /// <summary>
        /// 申请工作记录
        /// </summary>
        /// <returns></returns>
       public ActionResult JobResult()
        {
            ApplyJobBll bll = new ApplyJobBll();
           List<ApplyJob> model=  bll.GetUserList(ViewBag.Uid);
            return View(model);
        }
    }
}