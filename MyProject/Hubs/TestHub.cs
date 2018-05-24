using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace MyProject.Hubs
{
    [HubName("getMessage")]
    public class TestHub : Hub
    {
        public void SendMessage(string aaaa)
        {
            Clients.All.broadcastMessage(aaaa);
        }

        public void SendImage(string imagedata)
        {
            //获取图像数据,转发给其他客户端
            Clients.Others.showimage(new { id = Context.ConnectionId, data = imagedata });
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            Clients.Others.addKuang(Context.ConnectionId);
            return base.OnConnected();
        }
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            Clients.All.romeKuang(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }
    }
}