using MessagingService.src.Events;

namespace MessagingService.src.EventHandlers;

public class MesageSentEventHandler : IEventHandler<MessageSentEvent>
{
    public void Handle(MessageSentEvent @event)
    {
        throw new NotImplementedException();
    }
}