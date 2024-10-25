namespace MessagingService.src.Domain;

public class Channel
{
    public Guid ChannelID { get; set; }
    public required string ChannelName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
