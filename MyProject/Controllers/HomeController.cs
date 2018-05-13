using MyProject.EntitiesModel;
using MyProject.Models;
using MyProject.MyAttributes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Controllers
{
    public class HomeController : Controller
    {
        //值类型不允许赋值为null
        //如果要赋值为null的话，在数据类型后加上？ 例： int? DateTime?
        [HttpGet]
        public ActionResult Test(int? id)//形参名字要与路由中的参数名字一样  int? 表示为可以给int赋值为null
        {
            return View("/views/Company/index.cshtml");
        }

        [UserCheck]
        public ActionResult HomePage()
        {

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

    }
}