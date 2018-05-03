using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Bll;
using MyProject.EntitiesModel;
using MyProject.Common;
using Webdiyer.WebControls.Mvc;
namespace MyProject.Opportal.Controllers
{
    public class EditController : Controller
    {
        private UserInfoBll bllUserInfo = new UserInfoBll();
        private CompanyInfoBll bllCompany = new CompanyInfoBll();
        private OperatorBll bllOperator = new OperatorBll();
        // GET: Edit  管理员信息页
        public ActionResult Index(int page = 1)
        {
            int pageSize = 5;
            List<Operator> listModel = bllOperator.GetModelList();     //原list集合
            int counts = listModel.Count;
            PagedList<Operator> lst = listModel.ToPagedList(page,pageSize);  //转化为MvcPager所用的PageList
            lst.TotalItemCount = counts;
            lst.CurrentPageIndex = page;
            return View(lst);
        }



        /// <summary>
        /// 修改管理员信息
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangeOperator()
        {
            return View();
        }

        /// <summary>
        /// 添加管理员信息
        /// </summary>
        /// <returns></returns>
        public ActionResult AddOperator()
        {
            return View();
        }

        /// <summary>
        /// Post的处理添加管理员账户Action
        /// </summary>
        /// <param name="model">接收数据</param>
        /// <returns></returns>
        [HttpPost]
        public void AddOperator(Operator model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMsg = "请输入正确信息";
                return;
            }
            if (bllOperator.IsExisteUserName(model.OperatName))
            {
                ScriptHelper.AlertRefresh("已存在的用户名！");
                return;
            }
            if (bllOperator.AddModel(model))
            {
                ScriptHelper.AlertRefresh("注册成功！");
                return;
            }
            else
            {
                ScriptHelper.Alert("注册失败！");
            }
        }

        /// <summary>
        /// 删除管理员Action
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeleteOperator(string id = "0")
        {
            int modelId = 0;
            if (id == "0" || !int.TryParse(id, out modelId))
            {
                return RedirectToAction("Index");
            }
            if (bllOperator.DeleteModel(modelId))
            {
                return Content("<script>alert('删除成功！');javascript:location.href='/edit/index'</script>");
            }
            else
            {
                return Content("<script>alert('删除失败！');javascript:location.href='/edit/index'</script>");
            }

        }
    }
}