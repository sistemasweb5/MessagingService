
using MessagingService.src.Events.Interfaces;

namespace MessagingService.src.Events;

public class UserConnectedEvent : IEvent
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime Timestamp { get; } = DateTime.UtcNow;
    public string Username { get; set; }
    public DateTime EventDate { get; } = DateTime.UtcNow;
    public string EventType { get; } = nameof(UserConnectedEvent);

    public UserConnectedEvent(string username)
    {
        Username = username;
    }
}
