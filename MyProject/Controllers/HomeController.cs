using MyProject.EntitiesModel;
using MyProject.Bll;
using MyProject.MyAttributes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Webdiyer.WebControls.Mvc;

namespace MyProject.Controllers
{
    [UserCheck]
    public class HomeController : Controller
    {
        //值类型不允许赋值为null
        //如果要赋值为null的话，在数据类型后加上？ 例： int? DateTime?
        [HttpGet]
        public ActionResult Test(int? id)//形参名字要与路由中的参数名字一样  int? 表示为可以给int赋值为null
        {
            return View("/views/Company/index.cshtml");
        }


        public ActionResult HomePage()
        {
            EFDbContext db = BaseBll.db;
            var companyList = db.CompanyInfo.Where(o => o.IsIdentify == true)
                                             .Select(o => new
                                             {
                                                 o.ImgUrl,
                                                 o.CompanyId
                                             }).ToList();
            ViewBag.CompanyList = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(companyList));        //匿名类序列化成json对象
            return View();
        }

        public ActionResult Index()
        {
            #region 笔记
            ////ViewData
            //ViewData["Info"] = "招聘网";
            //ViewData["infolist"] = new List<string>() { "a", "b", "c" };
            ////TempData[""]  和 Viewdata使用一样
            //TempData["info"] = "招聘网";
            ////ViewBag 动态属性  实际上底层是使用viewdata来实现的
            //ViewBag.Info = "测试信息";
            //ViewBag.Info2 = "测试信息2";
            ////View(对象)
            //Person p = new Person { Id = "1", Name = "2" }; 
            #endregion
            return RedirectToAction("index", "login");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        //公司详情页
        public ActionResult CompanyInfo(int id = 0, int page = 1)
        {
            CompanyInfoBll bll = new CompanyInfoBll();
            UserInfoBll userbll = new UserInfoBll();
            CompanyInfo model = bll.GetModelById(id);
            bll.AddClickNum(id);

            ViewBag.UserJobList = userbll.GetUserJobIdList((int)ViewBag.Uid,0);     //获取用户申请的工作id列表

            //获取公司岗位信息
            JobsBll jobsbll = new JobsBll();
            PagedList<Jobs> jobList = jobsbll.GetPagedList(page, 10, id);
            ViewBag.JobList = jobList;
            if (Request.IsAjaxRequest())
            {
                return PartialView("CompanyJobList", jobList);
            }
            return View(model);
        }
    }
}