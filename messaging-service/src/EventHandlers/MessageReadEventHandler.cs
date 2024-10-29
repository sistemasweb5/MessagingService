using MessagingService.src.Events;
using MessagingService.src.Repositories;

namespace MessagingService.src.EventHandlers;

public class MessageReadEventHandler : IEventHandler<MessageReadEvent>
{
    private readonly MessageRepository _messageRepository;
    private readonly ChannelRepository _channelRepository;

    public MessageReadEventHandler(MessageRepository messageRepository, ChannelRepository channelRepository)
    {
        _messageRepository = messageRepository;
        _channelRepository = channelRepository;
    }

    public async void Handle(MessageReadEvent @event)
    {
        var message = await _messageRepository.GetByIdAsync(@event.MessageId);

        if (message == null) return;

        var channelExist = await _channelRepository.GetByIdAsync(@event.ChannelId);

        if (channelExist == null) return;

        message.Readed = true;

        await _messageRepository.UpdateAsync(message.MessageId, message);
    }
}