
namespace MessagingService.src.Events;

public class MessageReadEvent : IEvent
{
    public Guid MessageId { get; }
    public DateTime EventDate { get; }
    public Guid ChannelId { get; }

    public MessageReadEvent(Guid messageId, Guid channelId)
    {
        MessageId = messageId;
        ChannelId = channelId;
        EventDate = DateTime.Now;
    }
}
