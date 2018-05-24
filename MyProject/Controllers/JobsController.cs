using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Common;
using MyProject.Bll;
using MyProject.EntitiesModel;

namespace MyProject.Controllers
{
    public class JobsController : Controller
    {
        /// <summary>
        /// 申请职位
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        public void ApplyJob(EntitiesModel.ApplyJob model)
        {         
            if (model==null)
            {
                AjaxHelps.WriteErrorJson("申请失败");
                return;
            }
            
            model.Date = DateTime.Now;
            model.Status = 0;
            Bll.ApplyJobBll bll = new Bll.ApplyJobBll();
            int applyNum = bll.GetUserApplyNum(model.Uid,0);   //用户已申请的简历数
            if (applyNum == 5||applyNum>5)
            {
                AjaxHelps.WriteErrorJson("用户最只能投递5份简历");
                return;
            }
            if (bll.AddResume(model))
            {
                AjaxHelps.WriteSucessJson("申请成功");
            }
            else
            {
                AjaxHelps.WriteErrorJson("申请失败");
            }
        }
    }
}