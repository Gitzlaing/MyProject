using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using MyProject.EntitiesModel;

namespace MyProject.Bll {
    public class BaseBll
    {
        static public EFDbContext db
        {
            get
            {
                //从当前线程中获取MvcFirstCodeContext对象   CallContext 为线程缓存
                EFDbContext db = CallContext.GetData("DB") as EFDbContext;
                if (db == null)
                {
                    db = new EFDbContext();
                    CallContext.SetData("DB", db);
                }
                return db;
            }
        }
    }
}
