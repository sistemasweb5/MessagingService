using MessagingService.src.Events.Interfaces;

namespace MessagingService.src.Events;

public class NewMessageEvent : IEvent
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime Timestamp { get; } = DateTime.UtcNow;
    public string Content { get; set; }
    public string Email { get; set; }
    public Guid ChannelId { get; set; }
    public string EventType { get; } = nameof(NewMessageEvent);

    public NewMessageEvent(string message, string email, Guid channelId)
    {
        Content = message;
        Email = email;
        ChannelId = channelId;
    }
}
