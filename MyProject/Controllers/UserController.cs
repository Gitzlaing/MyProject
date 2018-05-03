using MyProject.EntitiesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Common;
using MyProject.MyAttributes;
using MyProject.Bll;
using System.Data.Entity.Infrastructure;

namespace MyProject.Controllers
{
    public class UserController : Controller
    {
        #region Remote特性验证用户名是否存在Action
        /// <summary>
        /// Remote特性验证用户名是否存在Action
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckUsername(string Username)
        {
            UserInfo ui = BaseBll.db.UserInfo.Where(o => o.Username == Username).FirstOrDefault();
            if (ui == null)
            {
                return Content("true");
            }
            else
            {
                return Content("false");
            }
        }
        #endregion
    }
}