using MessagingService.src.Domain;
using MessagingService.src.Events;
using MessagingService.src.Repositories;

namespace MessagingService.src.EventHandlers;

public class MesageSentEventHandler : IEventHandler<MessageSentEvent>
{
    private readonly MessageRepository _messageRepository;
    private readonly ChannelRepository _channelRepository;

    public MesageSentEventHandler(MessageRepository messageRepository, ChannelRepository channelRepository)
    {
        _messageRepository = messageRepository;
        _channelRepository = channelRepository;
    }

    public async void Handle(MessageSentEvent @event)
    {
        var channelExist = await _channelRepository.GetByIdAsync(@event.ChannelId);

        if (channelExist == null) return;
        
        var message = CreateMessage(@event.Content, @event.ChannelId, @event.UserId);
        await _messageRepository.InsertAsync(message);
    }

    private Message CreateMessage(string content, Guid channelId, Guid userId)
    {
        return new Message
            {
                Content = content,
                ChannelId = channelId,
                UserId = userId,
            };
    }
}
