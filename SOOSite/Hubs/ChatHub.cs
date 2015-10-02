using Microsoft.AspNet.SignalR;

namespace SOOSite.Hubs
{
    public class ChatHub : Hub
    {
        public void SendMessage(string message)
        {
            Clients.Others.addMessage(message);
        }

    }
}