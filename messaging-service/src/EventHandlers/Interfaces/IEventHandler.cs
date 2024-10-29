using MessagingService.src.Events.Interfaces;

namespace MessagingService.src.EventHandlers;

public interface IEventHandler<T> where T : IEvent
{
    void Handle(T @event);
}