using Angular_.NET_SignalR_ChatApp.Models;

namespace Angular_.NET_SignalR_ChatApp.Hubs
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(Message message);
    }
}
