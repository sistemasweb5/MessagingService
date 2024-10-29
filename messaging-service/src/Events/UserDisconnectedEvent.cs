using MessagingService.src.Events.Interfaces;

namespace MessagingService.src.Events;

public class UserDisconnectedEvent : IEvent
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime Timestamp { get; } = DateTime.UtcNow;
    public string User { get; set; }
    public DateTime EventDate { get; } = DateTime.UtcNow;
    public string EventType { get; } = nameof(UserConnectedEvent);

    public UserDisconnectedEvent(string user)
    {
        User = user;
    }
}
