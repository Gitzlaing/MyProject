using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Areas.Company.Controllers
{
    public class JobController : Controller
    {
        /// <summary>
        /// 发布工作
        /// </summary>
        /// <returns></returns>
        public ActionResult Release()
        {
            return View();
        }

        


        /// <summary>
        /// 删除工作信息
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteJob()
        {
            return new EmptyResult();
        }
    }
}