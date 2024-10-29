namespace MessagingService.src.Domain;
public class User
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public DateTime JoinedAt { get; set; }
}

