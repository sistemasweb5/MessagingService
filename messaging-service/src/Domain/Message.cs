namespace MessagingService.src.Domain;

public class Message
{
    public Guid MessageId { get; set; }
    public Guid ChannelId { get; set; }
    public Guid UserId { get; set; }
    public required string Content { get; set; }
    public DateTime Timestamp { get; set; }  
}
