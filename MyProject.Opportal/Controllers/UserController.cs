using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.EntitiesModel;
using MyProject.Common;
using MyProject.Bll;
namespace MyProject.Opportal.Controllers
{
    public class UserController : Controller
    {
        public int pageSize=5;
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult List(int page=1)
        {
            return PartialView();
        }
    }
}