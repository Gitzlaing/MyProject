using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Bll;
using MyProject.EntitiesModel;
using MyProject.Common;
namespace MyProject.Opportal.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Operator model)
        {
            OperatorBll bllOperator = new OperatorBll();
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!bllOperator.IsExisteUserName(model.OperatName))
            {
                ViewBag.ErrorMsg = "用户名不存在";
                return View();
            }
            if (!bllOperator.CheckUserName(model.OperatName, model.Password))
            {
                ViewBag.ErrorMsg = "用户名或密码错误";
                return View();
            }
            if (bllOperator.CheckUserName(model.OperatName, model.Password))
            {
                Session[Key.Current_Operator] = model;
                return RedirectToAction("Main", "home");
            }
            return View();
        }

    }
}