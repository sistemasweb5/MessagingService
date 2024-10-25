namespace MessagingService.src.Domain;

public class ChannelMember
{
    public Guid ChannelID { get; set; }
    public Guid UserID { get; set; }
    public DateTime JoinedAt { get; set; } = DateTime.Now;
}
