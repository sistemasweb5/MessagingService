namespace MessagingService.src.Events;

public class MessageSentEvent : IEvent
{  
    public Guid MessageId { get; }
    public DateTime EventDate { get; }
    public Guid ChannerlId { get; }

    public MessageSentEvent(Guid messageId, Guid channerlId)
    {
        MessageId = messageId;
        ChannerlId = channerlId;
        EventDate = DateTime.Now;
    }
}
