
using MessagingService.src.Events.Interfaces;

namespace MessagingService.src.Events;

public class MessageReadEvent : IEvent
{
    public Guid Id { get; }
    public Guid MessageId { get; }
    public Guid ChannelId { get; }
    public DateTime Timestamp { get; }

    public MessageReadEvent(Guid messageId, Guid channelId)
    {
        Id = Guid.NewGuid();
        MessageId = messageId;
        ChannelId = channelId;
        Timestamp = DateTime.Now;
    }
}
