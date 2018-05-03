using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Areas.Company.Controllers
{
    public class ImagesController : Controller
    {
        // GET: Company/Images
        public ActionResult Index()
        {
            return View();
        }

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

    }
}