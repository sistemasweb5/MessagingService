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

    public async Task SendMessage(string message, Guid channelId, Guid userId)
    {
        if (_connections.TryGetValue(Context.ConnectionId, out var user))
        {
            var newMessageEvent = new MessageSentEvent(message, channelId, userId);
            _eventBus.Publish(newMessageEvent);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }

    public async Task ReadMessage(Guid messageId, Guid channelId, Guid userId)
    {
        var newMessageEvent = new MessageReadEvent(messageId, channelId);
            _eventBus.Publish(newMessageEvent);
            await Clients.All.SendAsync("ReadMessage", messageId);
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
