using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.EntitiesModel;
using Webdiyer.WebControls.Mvc;

namespace MyProject.Bll
{
    public class JobsBll : BaseBll
    {

        /// <summary>
        /// 获取职位列表
        /// </summary>
        /// <returns></returns>
        public List<Jobs> GetModelList(int companyId)
        {
            List<Jobs> modelList = db.Jobs.Where(o => o.CompanyId == companyId).ToList();
            return modelList;
        }

        /// <summary>
        /// 获取分布列表
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="companyId">公司Id</param>
        /// <returns></returns>
        public PagedList<Jobs> GetPagedList(int pageIndex, int pageSize, int companyId)
        {
            IQueryable<Jobs> jobs = db.Jobs.Where(o => o.CompanyId == companyId);
            PagedList<Jobs> pagedList = jobs.OrderBy(o => o.CreateDate)
                                            .ToPagedList(pageIndex, pageSize);
            pagedList.TotalItemCount = jobs.Count();
            //pagedList.CurrentPageIndex = pageIndex;   MvcPager 3.0版本CurrentPageIndex可以自动生成，不用赋值
            return pagedList;
        }


        /// <summary>
        /// 添加模型
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool AddModel(Jobs model)
        {
            model.CreateDate = DateTime.Now;
            db.Jobs.Add(model);
            db.Configuration.ValidateOnSaveEnabled = false;
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
        /// 是否存在职位名称
        /// </summary>
        /// <param name="companyId">发布公司id</param>
        /// <param name="jobName">职位名称</param>
        /// <returns></returns>
        public bool IsExistsJob(int companyId, string jobName)
        {
            Jobs model = db.Jobs.Where(o => o.JobName == jobName).Where(o => o.CompanyId == companyId).FirstOrDefault();
            if (model == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 删除职位信息
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public bool DeleteJob(int jobId)
        {
            Jobs model = new Jobs { JobId = jobId };
            db.Jobs.Attach(model);
            db.Jobs.Remove(model);
            try
            {
                db.Configuration.ValidateOnSaveEnabled = false;
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
