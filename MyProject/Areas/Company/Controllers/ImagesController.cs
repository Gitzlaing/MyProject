using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.MyAttributes;
using MyProject.Bll;

namespace MyProject.Areas.Company.Controllers
{
    [CompanyUserCheck]
    public class ImagesController : Controller
    {
       
        #region 上传公司文件
        /// <summary>
        /// 上传公司文件
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadImg(HttpPostedFileBase img)
        {
            if (img == null)
            {
                return Content("false");
            }
            string strFileName = img.FileName;
            strFileName = Guid.NewGuid().ToString() + Path.GetExtension(strFileName);
            string path = "/UpLoad/" + strFileName;  //虚拟路径
            img.SaveAs(Server.MapPath(path));
            return Content(path);
        } 
        #endregion

        public FileResult GetUserAvatar(int id=0)
        {
            if (id==0)
            {
                return null;
            }
            //过滤获取用户id,防止获取其它的id
            CompanyInfoBll bll = new CompanyInfoBll();
            UserInfoBll userBll = new UserInfoBll();
            List<int> userList = bll.GetJobUserIdList(ViewBag.CompanyId);
            if (userList.Contains(id))
            {
                byte[] img = userBll.GetAvatar(id);
                return File(img, "image");
            }
            else
            {
                return null;
            }            
        }

    }
}