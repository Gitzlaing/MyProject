using System;
using System.Collections.Generic;
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
                return PartialView("CompanyList",pageList);
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
    }
}