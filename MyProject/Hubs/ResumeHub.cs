using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace MyProject.Hubs
{
    public class ResumeHub : Hub
    {
        public void broadCast()  //广播信息
        {
            Clients.All.SendResume();
        }
    }
}