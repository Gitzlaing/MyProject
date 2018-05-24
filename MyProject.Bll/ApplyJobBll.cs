using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.EntitiesModel;
namespace MyProject.Bll
{
    public class ApplyJobBll : BaseBll
    {

        /// <summary>
        /// 添加投递简历信息，申请职位操作
        /// </summary>
        /// <returns></returns>
        public bool AddResume(int companyId, int jobsId)
        {
            EntitiesModel.ApplyJob model = new EntitiesModel.ApplyJob() { CompanyId = companyId, JobId = jobsId };
            db.ApplyJob.Add(model);
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// AddResume重载
        /// </summary>
        /// <param name="cr"></param>
        /// <returns></returns>
        public bool AddResume(EntitiesModel.ApplyJob cr)
        {
            db.ApplyJob.Add(cr);
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取用户投递简历数
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int GetUserApplyNum(int uid,int status)
        {
            int num = 0;
            try
            {
                num = db.ApplyJob.Where(o => o.Uid == uid).Where(o=>o.Status==status).Count();
            }
            catch (Exception)
            {
                return 0;
            }
            return num;
        }

        /// <summary>
        /// List
        /// </summary>
        /// <param name="comapnyId"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<ApplyJob> GetList(int companyId, int uid)
        {
            return db.ApplyJob.Where(o => o.CompanyId == companyId && o.Uid == uid).ToList();
        }

        /// <summary>
        /// 获取企业简历箱
        /// </summary>
        /// <param name="companyId">公司Id</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public List<ApplyJob> GetCompanyList(int companyId, int status = 0)
        {
            return db.ApplyJob.Where(o => o.CompanyId == companyId).Where(o => o.Status == status).OrderByDescending(o => o.Date).ToList();
        }

        public List<ApplyJob> GetUserList(int uid)
        {
            return db.ApplyJob.Where(o => o.Uid == uid).ToList();
        }


        /// <summary>
        /// 拒绝简历操作
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public bool Refuse(int uid, int companyId, int jobId)
        {
            ApplyJob update = db.ApplyJob.Where(o => o.Uid == uid)
                                         .Where(o => o.CompanyId == companyId)
                                         .Where(o => o.JobId == jobId)
                                         .Where(o=>o.Status==0)
                                         .FirstOrDefault();
            update.Status = 3;
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
