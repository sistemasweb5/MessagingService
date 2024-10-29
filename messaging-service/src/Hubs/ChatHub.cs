using MessagingService.src.Events;
using MessagingService.src.Events.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace MessagingService.src.Hubs;

public class ChatHub : Hub
{
    private readonly IEventBus _eventBus;
    private static readonly Dictionary<string, string> _connections = new();

    public ChatHub(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }

    public async Task SendMessage(string message, Guid channelId)
    {
        if (_connections.TryGetValue(Context.ConnectionId, out var user))
        {
            var newMessageEvent = new NewMessageEvent(message, user, channelId);
            _eventBus.Publish(newMessageEvent);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }

    public override async Task OnConnectedAsync()
    {
        var user = Context.User?.Identity?.Name ?? "UnknownUser";
        _connections[Context.ConnectionId] = user;
        _eventBus.Publish(new UserConnectedEvent(user));
        await Clients.All.SendAsync("UserConnected", user);
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        if (_connections.TryGetValue(Context.ConnectionId, out var user))
        {
            _connections.Remove(Context.ConnectionId);
            _eventBus.Publish(new UserDisconnectedEvent(user));
            await Clients.All.SendAsync("UserDisconnected", user);
        }
        await base.OnDisconnectedAsync(exception);
    }

    public async Task UserTyping()
    {
        if (_connections.TryGetValue(Context.ConnectionId, out var user))
        {
            await Clients.Others.SendAsync("ReceiveTypingNotification", user);
        }
    }
}
