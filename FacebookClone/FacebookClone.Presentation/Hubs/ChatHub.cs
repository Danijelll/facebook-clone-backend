using FacebookClone.Presentation.ConnectionMapping;
using Microsoft.AspNetCore.SignalR;

namespace FacebookClone.Presentation.Hubs
{
    public class ChatHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections =
       new ConnectionMapping<string>();
        public async Task SendMessage(string sender, string receiver, string message)
        {

            foreach (var connectionId in _connections.GetConnections(receiver))
            {
                Clients.Client(connectionId).SendAsync("ReceiveMessage", sender, message);
            }
        }
        public void OnConnected(string name)
        {
            _connections.Add(name, Context.ConnectionId);
        }
        public Task OnDisconnected(bool stopCalled)
        {
            string name = Context.User.Identity.Name;

            _connections.Remove(name, Context.ConnectionId);

            return OnDisconnected(stopCalled);
        }

        public Task OnReconnected()
        {
            string name = Context.User.Identity.Name;

            if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                _connections.Add(name, Context.ConnectionId);
            }

            return OnReconnected();
        }
    }
}
