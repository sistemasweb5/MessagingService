namespace MessagingService.src.Domain;

public class Message
{
    public Guid MessageId { get; set; }
    public Guid ChannelId { get; set; }
    public Guid UserId { get; set; }
    public required string Content { get; set; }
    public DateTime SentAt { get; set; }
    public bool Readed { get; set; }

    public Message()
    {
        MessageId = Guid.NewGuid();
        SentAt = DateTime.UtcNow;
        Readed = false;
    }
}
