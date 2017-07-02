using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;

namespace Chicken.signalR
{
    [HubName("DataTickerHub")]
    public class DataTickerHub : Hub
    {
        private RedisDataTicker redisDataTicker;

        public DataTickerHub() : this(RedisDataTicker.Instance) { }

        public DataTickerHub(RedisDataTicker redisDataTicker)
        {
            redisDataTicker = redisDataTicker;
        }

        public void GetAllData()
        {
            string username = Context.User.Identity.Name;
            string project = "26";

            redisDataTicker.GetAllData(Context.ConnectionId, project);
        }
        public void SendCommand(string data)
        {
            string name = Context.User.Identity.Name;
            redisDataTicker.SendCommandToQueue(name, data);
        }

        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;

            string project = "26";

            redisDataTicker.ProjectUserConnections.AddOrUpdate(
                    project,
                    key =>
                    {
                        redisDataTicker.RegisterRedisChannel(project);
                        return new HashSet<MyUser>() { new MyUser() { connection = Context.ConnectionId, Username = name } };

                    },
                    (key, oldValue) =>
                    {
                        oldValue.Add(new MyUser() { connection = Context.ConnectionId, Username = name });
                        return oldValue;
                    }
            );

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string name = Context.User.Identity.Name;
            string project = "26";

            redisDataTicker.ProjectUserConnections[project].RemoveWhere(m => m.Username == name);

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            string name = Context.User.Identity.Name;
            string project = "26";

            redisDataTicker.ProjectUserConnections.AddOrUpdate(
                   project,
                   key =>
                   {
                       return new HashSet<MyUser>() { new MyUser() { connection = Context.ConnectionId, Username = name } };
                   },
                   (key, oldValue) =>
                   {
                       oldValue.Add(new MyUser() { connection = Context.ConnectionId, Username = name });
                       return oldValue;
                   }
           );

            return base.OnReconnected();
        }

    }
}