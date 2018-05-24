using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.MyAttributes;
using MyProject.Bll;
using MyProject.EntitiesModel;

namespace MyProject.Areas.User.Controllers
{
    [UserCheck]
    public class MessageController : Controller
    {
        public ActionResult Notify()
        {
            return View();
        }
    }
}