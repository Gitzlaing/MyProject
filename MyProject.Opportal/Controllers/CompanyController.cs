using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Bll;
using MyProject.Common;
using MyProject.EntitiesModel;
using Webdiyer.WebControls.Mvc;

namespace MyProject.Opportal.Controllers
{
    public class CompanyController : Controller
    {
        private CompanyInfoBll bllCompany = new CompanyInfoBll();
        // GET: Company
        /// <summary>
        /// 默认视图，显示企业用户列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int pageIndex = 1)
        {
            int pageSize = 5;
            PagedList<CompanyInfo> pageList = bllCompany.GetPaging(pageIndex, pageSize);

            if (Request.IsAjaxRequest())   //判断如果是Ajax请求就执行
            {
                return PartialView("CompanyList", pageList);
            }
            return View(pageList);
        }


        public ActionResult ShowInfo(int id = 0)
        {
            CompanyInfo model = bllCompany.GetModelById(id);
            if (model == null)
            {
                return View(new CompanyInfo());
            }
            else
            {
                return View(model);
            }
        }


        [HttpGet]
        public void DeleteInfo(int id = 0, int id2 = 0)
        {
            if (!bllCompany.DeleteInfo(id))
            {
                AjaxHelps.WriteErrorJson("删除失败");
            }
            else
            {
                AjaxHelps.WriteSucessJson("删除成功");
            }
        }

        /// <summary>
        /// 认证企业Action
        /// </summary>
        /// <param name="id">认证公司id</param>
        /// <returns></returns>
        [HttpGet]
        public void Authen(int id = 0)
        {
            EFDbContext db = BaseBll.db;
            if (id == 0)
            {
                AjaxHelps.WriteErrorJson("认证失败");
            }
            else
            {
                CompanyInfo ci = new CompanyInfo { CompanyId = id, IsIdentify = true };
                try
                {
                    DbEntityEntry<CompanyInfo> entry = db.Entry<CompanyInfo>(ci);
                    entry.State = System.Data.Entity.EntityState.Unchanged;
                    entry.Property("IsIdentify").IsModified = true;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    AjaxHelps.WriteErrorJson("认证失败");
                    return;
                }

                AjaxHelps.WriteSucessJson("认证成功");
            }
        }

        /// <summary>
        /// 取消认证企业Action
        /// </summary>
        /// <param name="companyId"></param>
        [HttpGet]
        public void UnAuthen(int id)
        {
            EFDbContext db = BaseBll.db;
            if (id == 0)
            {
                AjaxHelps.WriteErrorJson("取消失败");
            }
            else
            {
                CompanyInfo ci = new CompanyInfo { CompanyId = id, IsIdentify = false };
                try
                {
                    DbEntityEntry<CompanyInfo> entry = db.Entry<CompanyInfo>(ci);
                    entry.State = System.Data.Entity.EntityState.Unchanged;
                    entry.Property(o => o.IsIdentify).IsModified = true;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    AjaxHelps.WriteErrorJson("取消失败");
                }

                AjaxHelps.WriteSucessJson("取消成功");
            }
        }
    }
}