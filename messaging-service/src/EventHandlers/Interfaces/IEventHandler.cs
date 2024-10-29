namespace MessagingService.src.EventHandlers.Interfaces;

public interface IEventHandler<T>
{
    void Handle(T @event);
}