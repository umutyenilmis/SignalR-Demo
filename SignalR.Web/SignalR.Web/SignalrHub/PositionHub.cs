using SignalR.Hubs;


namespace SignalR.Web.SignalrHub
{
    public class PositionHub : Hub
    {
        public void Send(string message)
        {
            
        }

        public void ObjectPosition(int x, int y)
        {
            var caller = Clients.Caller;

            Clients.setNewPosition(x, y);
        }

        public void AskCurrentPosition()
        {
            Clients.setNewPosition(400, 300);
        }
    }
}