using FacebookClone.BLL.DTO.Message;
using FacebookClone.BLL.Services;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.Presentation.ConnectionMapping;
using Microsoft.AspNetCore.SignalR;

namespace FacebookClone.Presentation.Hubs
{
    public class ChatHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections = new ConnectionMapping<string>();

        public async Task SendMessage(string senderId, string receiverId, string text)
        {
            MessageDTO messageDTO = new MessageDTO
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Text = text,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
            };

            foreach (var connectionId in _connections.GetConnections(receiverId))
            {
                Clients.Client(connectionId).SendAsync("ReceiveMessage", messageDTO);
            }
            foreach (var connectionId in _connections.GetConnections(senderId))
            {
                Clients.Client(connectionId).SendAsync("ReceiveMessage", messageDTO);
            }
        }
        public void OnConnected(string id)
        {
            _connections.Add(id, Context.ConnectionId);
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
