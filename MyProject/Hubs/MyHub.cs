using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using MyProject.EntitiesModel;
using MyProject.Bll;
using MyProject.Common;

namespace MyProject.Hubs
{
    public class MyHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public void CompanyIdentityStatus()
        {
            //EFDbContext db = BaseBll.db;
            //bool isIdentity = db.CompanyInfo.Where(o => o.CompanyId == companyId).Select(o => o.IsIdentify).FirstOrDefault();
            Clients.All.identityStatus();
        }
    }
}