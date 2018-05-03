using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Areas.Company.Controllers
{
    public class ResumeController : Controller
    {
        // GET: Company/Resume
        public ActionResult Index()
        {
            return View();
        }
    }
}