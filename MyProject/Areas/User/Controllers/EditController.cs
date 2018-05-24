using MyProject.Common;
using MyProject.EntitiesModel;
using MyProject.MyAttributes;
using MyProject.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Areas.User.Controllers
{
    [UserCheck]    
    public class EditController : Controller
    {
        UserInfoBll bllUserInfo = new UserInfoBll();
        // GET: User/Edit
        public ActionResult Index()
        {
            return RedirectToAction("BaseInfo");
        }

        public ActionResult BaseInfo()
        {
            UserInfo currentUser = (UserInfo)Session[Key.Current_User];
            return View(currentUser);
        }

        /// <summary>
        /// post提交保存求职用户信息
        /// </summary>
        /// <param name="postModel"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BaseInfo(UserInfo postModel, HttpPostedFileBase image = null)
        {
            UserInfo currentUser = (UserInfo)Session[Key.Current_User];
            if (postModel == null)
            {
                return View(currentUser);
            }
            if (image != null)
            {
                postModel.Avatar = new byte[image.ContentLength];
                image.InputStream.Read(postModel.Avatar, 0, image.ContentLength);
            }
            if (bllUserInfo.UpdateBaseInfo(postModel))
            {
                ViewBag.Msg = "保存成功";
                currentUser = (UserInfo)Session[Key.Current_User];
            }
            else
            {
                ViewBag.Msg = "保存失败";
            }
            return View(currentUser);
        }

        public ActionResult WorkExperience()
        {
            return View();
        }
        public ActionResult ProjectExperience()
        {
            return View();
        }

        /// <summary>
        /// 获取用户头像    
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public FileResult GetAvatarImg()
        {
            UserInfo model = (UserInfo)Session[Key.Current_User];
            if (model == null)
            {
                return null;
            }
            if (model.Avatar == null) 
            {
                return null;
            }
            return File(model.Avatar, "image");
        }

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