
namespace MessagingService.src.Events;

public class MessageReadEvent : IEvent
{
    public Guid MessageId { get; }
    public DateTime EventDate { get; }
    public Guid ChannerlId { get; }

    public MessageReadEvent(Guid messageId, Guid channerlId)
    {
        MessageId = messageId;
        ChannerlId = channerlId;
        EventDate = DateTime.Now;
    }
}
