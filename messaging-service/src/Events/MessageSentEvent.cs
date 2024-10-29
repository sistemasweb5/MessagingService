using MessagingService.src.Events.Interfaces;

namespace MessagingService.src.Events;

public class MessageSentEvent : IEvent
{  
    public Guid Id { get; }
    public string Content { get; }
    public DateTime Timestamp { get; }
    public Guid ChannelId { get; }
    public Guid UserId { get; }

    public MessageSentEvent(string content, Guid channelId, Guid userId)
    {
        Content = content;
        ChannelId = channelId;
        UserId = userId;
        Timestamp = DateTime.Now;
    }
}
