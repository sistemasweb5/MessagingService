namespace MessagingService.src.Events.Interfaces;

public interface IEvent
{
    Guid Id { get; }
    DateTime Timestamp { get; }
}
