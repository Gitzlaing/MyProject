using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.EntitiesModel;
using System.Web;
using MyProject.Common;
using Webdiyer.WebControls.Mvc;

namespace MyProject.Bll
{
    public class CompanyInfoBll : BaseBll
    {
        //public CompanyInfo GetEmptyModel()
        //{
        //    CompanyInfo model = new CompanyInfo();
        //    model.Username = "";
        //    model.PassWord = "";
        //    model.Address = "";
        //    model.Tel = "";
        //    model.Email = "";
        //    model.Manager = "";
        //    return model;
        //}

        #region 创建企业账号
        /// <summary>
        /// 创建企业账号
        /// </summary>
        /// <param name="username">企业用户名</param>
        /// <param name="password">企业密码</param>
        /// <returns></returns>
        public bool CreateCompanyAccount(string username, string password)
        {
            CompanyInfo ci = new CompanyInfo();
            db.Configuration.ValidateOnSaveEnabled = false;
            ci.Username = username;
            ci.PassWord = password;
            ci.CreateDate = DateTime.Now;
            ci.Click = 0;
            ci.IsIdentify = false;
            db.CompanyInfo.Add(ci);
            int num = db.SaveChanges();
            if (num > 0)
            {
                HttpContext.Current.Session[Key.Current_Company] = ci;
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion
        
        #region 更新企业账号信息
        /// <summary>
        /// 更新企业账号信息
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateCompanyInfo(int companyId, CompanyInfo model)
        {
            db.Configuration.ValidateOnSaveEnabled = false;
            CompanyInfo updateMdoel = db.CompanyInfo.Where(o => o.CompanyId == companyId).FirstOrDefault();
            if (updateMdoel != null)
            {
                updateMdoel.ImgUrl = model.ImgUrl == null ? updateMdoel.ImgUrl : model.ImgUrl;
                updateMdoel.LicenseUrl = model.LicenseUrl == null ? updateMdoel.LicenseUrl : model.LicenseUrl;
                updateMdoel.CompanyName = model.CompanyName;
                updateMdoel.Address = model.Address;
                updateMdoel.Manager = model.Manager;
                updateMdoel.Tel = model.Tel;
                updateMdoel.Describe = model.Describe;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    return false;
                }
                HttpContext.Current.Session[Key.Current_Company] = updateMdoel;
                return true;
            }
            else
            {
                return false;
            }
        } 
        #endregion

        #region 是否存在企业用户名
        /// <summary>
        /// 是否存在企业用户名
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsExistUserName(string username)
        {
            CompanyInfo ci = db.CompanyInfo.Where(o => o.Username == username).FirstOrDefault();
            if (ci == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        #endregion

        #region 获取公司账号总数
        /// <summary>
        /// 获取公司账号总数
        /// </summary>
        /// <returns></returns>
        public int GetRecords()
        {
            int records = db.CompanyInfo.Count();
            if (records > 0)
            {
                return records;
            }
            return 0;
        }
        #endregion

        /// <summary>
        /// 获取CompanyList
        /// </summary>
        /// <returns></returns>
        public List<CompanyInfo> GetModelList()
        {
            return db.CompanyInfo.OrderBy(o => o.CompanyId).ToList();
        }


        #region 获取分页数据表,mvc分页控件PageList
        /// <summary>
        /// 获取分页数据表,mvc分页控件PageList
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public PagedList<CompanyInfo> GetPaging(int pageIndex, int pageSize)
        {
            PagedList<CompanyInfo> pagedList = db.CompanyInfo
                                              .OrderBy(o => o.CompanyId)
                                              .ToPagedList(pageIndex, pageSize);
            pagedList.TotalItemCount = GetRecords();
            pagedList.CurrentPageIndex = pageIndex;
            return pagedList;
        }
        #endregion


        #region 由企业ID获取Model
        /// <summary>
        /// 由企业ID获取Model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CompanyInfo GetModelById(int id)
        {
            return db.CompanyInfo.Where(o => o.CompanyId == id).FirstOrDefault();
        }
        #endregion

        #region 根据CompanyId删除信息
        /// <summary>
        /// 根据CompanyId删除信息
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public bool DeleteInfo(int companyId)
        {
            CompanyInfo model = new CompanyInfo { CompanyId = companyId };
            db.CompanyInfo.Attach(model);
            db.CompanyInfo.Remove(model);
            int num = db.SaveChanges();
            if (num > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
