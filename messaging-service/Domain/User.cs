namespace messaging_service.Domain;

public class User
{
    public Guid UserId { get; set; }
    public required string Username { get; set; }
}
