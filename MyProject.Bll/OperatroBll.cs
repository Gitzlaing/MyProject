using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.EntitiesModel;
namespace MyProject.Bll
{
    public class OperatorBll :BaseBll
    {
        #region 验证账号是否存在
        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool IsExisteUserName(string username)
        {
                Operator model = db.Operator.Where(o => o.OperatName == username).FirstOrDefault();
                if (model == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
        }
        #endregion

        #region 检查用户名登录
        /// <summary>
        /// 检查用户名登录 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckUserName(string username, string password)
        {
                Operator model = db.Operator.Where(o => o.OperatName == username).Where(o => o.Password == password).FirstOrDefault();
                if (model == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
        }
        #endregion

        /// <summary>
        /// 获取List集合
        /// </summary>
        /// <returns></returns>
        public List<Operator> GetModelList()
        {
                List<Operator> modelList = db.Operator.OrderBy(o=>o.OperatorId).ToList();
                return modelList;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        public bool AddModel(Operator model)
        {
            if (model == null)
            {
                return false;
            }
                db.Configuration.ValidateOnSaveEnabled = false;
                db.Operator.Add(model);
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }


        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteModel(int id)
        {
                Operator model = db.Operator.Where(o => o.OperatorId == id).FirstOrDefault();
                if (model != null)
                {
                    db.Operator.Remove(model);
                    if (db.SaveChanges() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
        }

        /// <summary>
        /// 获取分页数据表
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public List<Operator> GetPaging(int pageIndex, int pageSize)
        {
                return db.Operator.OrderBy(o => o.OperatorId).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
