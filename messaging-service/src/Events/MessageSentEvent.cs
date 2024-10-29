namespace MessagingService.src.Events;

public class MessageSentEvent : IEvent
{  
    public string Content { get; }
    public DateTime EventDate { get; }
    public Guid ChannelId { get; }
    public Guid UserId { get; }

    public MessageSentEvent(string content, Guid channelId, Guid userId)
    {
        Content = content;
        ChannelId = channelId;
        UserId = userId;
        EventDate = DateTime.Now;
    }
}
