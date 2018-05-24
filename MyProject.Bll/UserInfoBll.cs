using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.EntitiesModel;
using System.Web;
using MyProject.Common;

namespace MyProject.Bll
{
    public class UserInfoBll : BaseBll
    {

        #region 生成初始化的实体
        /// <summary>
        /// 生成初始化的实体
        /// </summary>
        /// <returns></returns>
        public UserInfo GetEmptyModel()
        {
            UserInfo model = new UserInfo();
            model.Username = "";
            model.Password = "";
            model.Name = "";
            model.Tel = "";
            model.Email = "";
            model.Sex = true;
            model.School = "";
            model.Specialty = "";
            model.Describe = "";
            model.BirthDate = DateTime.Now;
            model.Knowledge = "";
            model.CreateDate = DateTime.Now;
            return model;
        }
        #endregion

        #region 获取一个实体
        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <returns></returns>
        public UserInfo GetModel(int uid = 0)
        {
            return db.UserInfo.Where(o => o.Uid == uid).FirstOrDefault();
        }
        #endregion

        #region 是否存在求职用户名
        /// <summary>
        /// 是否存在求职用户名
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsExistUserName(string username)
        {
            UserInfo model = db.UserInfo.Where(o => o.Username == username).FirstOrDefault();
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

        #region 创建求职用户
        /// <summary>
        /// 创建求职用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        public bool CreateUserAccount(string username, string password)
        {
            UserInfo ui = new UserInfo();
            db.Configuration.ValidateOnSaveEnabled = false;
            ui.Username = username;
            ui.Password = password;
            ui.CreateDate = DateTime.Now;
            db.UserInfo.Add(ui);
            int num = db.SaveChanges();
            if (num > 0)
            {
                HttpContext.Current.Session[Key.Current_User] = ui;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 获取用户数
        /// <summary>
        /// 获取用户数
        /// </summary>
        /// <returns></returns>
        public int GetRecords()
        {
            int records = db.UserInfo.Count();
            if (records >= 0)
            {
                return records;
            }
            return 0;
        }
        #endregion

        #region 更新基本信息
        /// <summary>
        /// 更新基本信息
        /// </summary>
        /// <returns></returns>
        public bool UpdateBaseInfo(UserInfo model)
        {
            UserInfo currentModel = (UserInfo)HttpContext.Current.Session[Key.Current_User];
            if (currentModel == null || model == null)
            {
                return false;
            }
            try
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                UserInfo updateModel = db.UserInfo.Where(o => o.Uid == currentModel.Uid).FirstOrDefault();
                updateModel.Name = model.Name;
                updateModel.BirthDate = model.BirthDate;
                updateModel.Describe = model.Describe;
                updateModel.Email = model.Email;
                updateModel.Knowledge = model.Knowledge;
                updateModel.School = model.School;
                updateModel.Sex = model.Sex;
                updateModel.Specialty = model.Specialty;
                updateModel.Tel = model.Tel;
                if (model.Avatar != null)
                {
                    updateModel.Avatar = model.Avatar;
                }
                db.SaveChanges();
                HttpContext.Current.Session[Key.Current_User] = updateModel;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #endregion

        /// <summary>
        /// 获取求职用户求职的工作ID列表
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="status">求职工作状态类型</param>
        /// <returns></returns>
        public List<int> GetUserJobIdList(int uid, int status)
        {
            return db.ApplyJob.Where(o => o.Uid == uid).Where(o => o.Status == status).Select(o => o.JobId).Distinct().ToList();
        }

        /// <summary>
        /// 获取用户头像
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public byte[] GetAvatar(int uid)
        {
            return db.UserInfo.Where(o => o.Uid == uid).Select(e => e.Avatar).FirstOrDefault();
        }
    }
}
