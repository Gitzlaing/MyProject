using MyProject.EntitiesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Common;
using MyProject.Bll;
namespace MyProject.Controllers
{
    public class RegisterController : Controller
    {
        UserInfoBll bllUserInfo = new UserInfoBll();
        CompanyInfoBll bllCompanyInfo = new CompanyInfoBll();
        EFDbContext db = BaseBll.db;
        // GET: Register
        public ActionResult Index(string typeid)
        {
            int type = Convert.ToInt32(typeid);
            if (type == 1)
            {
                ViewBag.Type = 1;
                ViewBag.TypeName = "求职";
            }
            else
            {
                ViewBag.Type = 2;
                ViewBag.TypeName = "企业";
            }
            return View("Register");
        }

        #region 检查注册步骤及类型
        /// <summary>
        /// 检查注册步骤及类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="steps">步骤</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CheckSteps(int type, int steps)
        {
            if (type == 1)
            {
                switch (steps)
                {
                    case 0:
                        return PartialView("RegisterUserAccount");
                    case 1:
                        return PartialView("/Views/Register/RegisterUser.cshtml");
                    default:
                        return PartialView("/Views/Register/RegisterFinish.cshtml");
                }
            }
            switch (steps)
            {
                case 0:
                    return PartialView("/Views/Register/RegisterCompanyaccount.cshtml");
                case 1:
                    return PartialView("/Views/Register/RegisterCompany.cshtml");
                default:
                    return PartialView("/Views/Register/RegisterFinish.cshtml");
            }

        }
        #endregion

        #region 创建求职用户账号
        /// <summary>
        /// 创建求职用户账号
        /// </summary>
        /// <param name="ui"></param>
        [HttpPost]
        public void CreateUserAccout(UserInfo ui)
        {
            ModelState.Remove("Name");
            if (!ModelState.IsValid)
            {
                AjaxHelps.WriteErrorJson("请填写正确信息");
                return;
            }
            if (bllUserInfo.IsExistUserName(ui.Username))
            {
                AjaxHelps.WriteErrorJson("已存在该用户名！");
                return;
            }
            if (bllUserInfo.CreateUserAccount(ui.Username, ui.Password))
            {
                AjaxHelps.WriteSucessJson("注册成功");
            }
            else
            {
                AjaxHelps.WriteErrorJson("服务错误，请稍后重试！");
            }
            return;
        }
        #endregion

        #region 创建公司账号
        /// <summary>
        /// 创建公司账号
        /// </summary>
        /// <param name="ci"></param>
        /// <returns></returns>
        [HttpPost]
        public void CreateCompanyAccount(CompanyInfo ci)
        {
            ModelState.Remove("CompanyName");
            if (!ModelState.IsValid)
            {
                AjaxHelps.WriteErrorJson("请填写正确信息");
                return;
            }
            if (bllCompanyInfo.IsExistUserName(ci.Username))
            {
                AjaxHelps.WriteErrorJson("已存在该用户名！");
                return;
            }
            if (bllCompanyInfo.CreateCompanyAccount(ci.Username, ci.PassWord))
            {
                AjaxHelps.WriteSucessJson("注册成功");
            }
            else
            {
                AjaxHelps.WriteErrorJson("服务错误，请稍后重试！");
            }
            return;
        }
        #endregion

        #region 添加求职用户信息
        /// <summary>
        /// 添加求职用户信息
        /// </summary>
        /// <param name="postModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddUserInfo(UserInfo postModel)
        {
            ModelState.Remove("Username");
            ModelState.Remove("Password");
            ModelState.Remove("RePassword");
            if (!ModelState.IsValid)
            {
                return Content("false");
            }
            if (Session[Key.Current_User] != null)
            {
                UserInfo currentUser = (UserInfo)Session[Key.Current_User];
                int uid = currentUser.Uid;
                db.Configuration.ValidateOnSaveEnabled = false;
                UserInfo model = db.UserInfo.Where(o => o.Uid == uid).FirstOrDefault();
                model.BirthDate = postModel.BirthDate;
                model.Describe = postModel.Describe;
                model.Email = postModel.Email;
                model.Knowledge = postModel.Knowledge;
                model.Name = postModel.Name;
                model.School = postModel.School;
                model.Sex = postModel.Sex;
                model.Specialty = postModel.Specialty;
                model.Tel = postModel.Tel;
                db.SaveChanges();
                return Content("Success");

            }
            else
            {
                return Content("TimeOut");
            }
        }
        #endregion

        /// <summary>
        /// 添加企业用户信息
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCompanyInfo(CompanyInfo model)
        {
            ModelState.Remove("Username");
            ModelState.Remove("PassWord");
            ModelState.Remove("RePassWord");
            if (!ModelState.IsValid)
            {
                return Content("");
            }
            if (Session[Key.Current_Company] != null)
            {
                CompanyInfo ci = (CompanyInfo)Session[Key.Current_Company];
                db.Configuration.ValidateOnSaveEnabled = false;  //取消验证信息
                CompanyInfo dbModel = db.CompanyInfo.Where(o => o.CompanyId == ci.CompanyId).FirstOrDefault();
                dbModel.CompanyName = model.CompanyName;
                dbModel.ImgUrl = model.ImgUrl;
                dbModel.LicenseUrl = model.LicenseUrl;
                dbModel.Address = model.Address;
                dbModel.Manager = model.Manager;
                dbModel.Tel = model.Tel;
                dbModel.Describe = model.Describe;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return Content("false");
                }

                return Content("Success");

            }
            else
            {
                return Content("TimeOut");
            }
        }

        #region 分布视图
        public ActionResult RegisterUserAccount()
        {
            return PartialView();
        }

        public ActionResult RegisterUser()
        {
            return PartialView();
        }

        public ActionResult RegisterCompanyAccount()
        {
            return PartialView();
        }

        public ActionResult RegisterFinish()
        {
            return PartialView();
        }

        public ActionResult RegisterCompany()
        {
            return PartialView();
        }


        #endregion


    }
}