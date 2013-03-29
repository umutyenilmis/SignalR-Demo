using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;



namespace SignalR.Web.SignalrHub
{
    public static class UserHandler
    {
        public static IList<ClientUser> ClientList = new List<ClientUser>();

        public class ClientUser
        {
            public string ConnectionId { get; set; }
            public string UserName { get; set; }
        }
    }

    [HubName("positionHub")]
    public class PositionHub : Hub
    {
        public override Task OnConnected()
        {
            UserHandler.ClientList.Add(new UserHandler.ClientUser
                {
                    ConnectionId = Context.ConnectionId
                });

            return base.OnConnected();
        }

        public override Task OnDisconnected()
        {
            UserHandler.ClientList.Remove(new UserHandler.ClientUser
            {
                ConnectionId = Context.ConnectionId
            });
            foreach (var client in UserHandler.ClientList.Where(client => client.ConnectionId == Context.ConnectionId))
                UserLeft(client.UserName);

            return base.OnDisconnected();
        }
        private static void SetUserName(string userName, string clientId)
        {
            foreach (var client in UserHandler.ClientList.Where(client => client.ConnectionId == clientId))
                client.UserName = userName;
        }

        public void ObjectPosition(int x, int y)
        {
            Clients.Others.setNewPosition(x, y);

        }
        public void UserJoined(string userName)
        {
            SetUserName(userName, Context.ConnectionId);
            Clients.Others.DispatchUserJoined(userName);
        }
        private void UserLeft(string userName)
        {
            Clients.All.UserLeft(userName);
        }
        public void SendMessage(string msg, string userName)
        {
            Clients.Others.DispatchMessage(msg, userName);
        }
        public void AskCurrentPosition()
        {
            if (UserHandler.ClientList.Count == 1)
                Clients.Caller.setNewPosition(15, 15);
            else
                Clients.Others.requestPosition();
        }

    }
}