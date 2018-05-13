using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Bll;
using MyProject.Common;
using MyProject.EntitiesModel;
using MyProject.MyAttributes;
using Webdiyer.WebControls.Mvc;

namespace MyProject.Areas.Company.Controllers
{
    [CompanyUserCheck]
    public class JobController : Controller
    {
        EFDbContext db = BaseBll.db;
        /// <summary>
        /// 发布工作
        /// </summary>
        /// <returns></returns>
        public ActionResult Release()
        {
            ViewBag.JobTypeList = GetJobTypeList();
            return View();
        }

        /// <summary>
        /// 发布职位Action
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Release(Jobs model)
        {
            JobsBll bll = new JobsBll();
            ViewBag.JobTypeList = GetJobTypeList();
            if (bll.IsExistsJob(model.CompanyId,model.JobName))  //判断职位名称是否重复
            {
                ViewBag.Msg = "  已存在的职位名称，请重新发布";
                return View();
            }
            if (bll.AddModel(model))
            {
                ViewBag.Msg = "  发布成功";
            }
            else
            {
                ViewBag.Msg = " 发布失败";
            }

            return View();
        }


        /// <summary>
        /// 管理职位操作
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int Id=0,int page=1)
        {
            JobsBll bll = new JobsBll();
              bll.DeleteJob(Id);
            return View(bll.GetPagedList(page, 10, ViewBag.CompanyId));
        }


        /// <summary>
        /// 职位管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int page=1)
        {
            int pageSize = 10;
            JobsBll bll = new JobsBll();
            PagedList<Jobs> jobList = bll.GetPagedList(page,pageSize,ViewBag.CompanyId);
            return View(jobList);
        }


        /// <summary>
        /// 获取职位分类列表
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> GetJobTypeList()
        {
            List<JobType> jobTypeList = db.JobType.ToList();
            List<SelectListItem> jobList = new List<SelectListItem>();

            if (jobTypeList != null)
            {
                foreach (var item in jobTypeList)
                {
                    jobList.Add(new SelectListItem { Text = item.Name, Value = item.TypeId.ToString() });
                }
            }
            else
            {
                jobList.Add(new SelectListItem { Text = "加载出错", Value = "0" });
            }
            return jobList;
        }
    }
}