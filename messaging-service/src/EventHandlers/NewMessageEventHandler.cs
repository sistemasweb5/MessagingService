using MessagingService.src.Domain;
using MessagingService.src.Events;
using MessagingService.src.Repositories;

namespace MessagingService.src.EventHandlers;

public class NewMessageEventHandler
{
    private readonly MessageRepository _messageRepository;
    private readonly ChannelRepository _channelRepository;
    private readonly UserRepository _userRepository;

    public NewMessageEventHandler(
        MessageRepository messageRepository,
        UserRepository userRepository,
        ChannelRepository channelRepository)
    {
        _messageRepository = messageRepository;
        _channelRepository = channelRepository;
        _userRepository = userRepository;
    }

    public async void Handle(NewMessageEvent @event)
    {
        var user = await _userRepository.GetUserByEmail(@event.Email); 
        if (user == null) return;

        var channel = await GetChannelById(@event.ChannelId);
        if (channel == null) return;

        await CreateMessage(user.UserId, channel.ChannelID, @event.Content);
    }

    private async Task<Channel?> GetChannelById(Guid channelId)
    {
        return await _channelRepository.GetByIdAsync(channelId);
    }

    private async Task CreateMessage(Guid userId, Guid channelId, string content)
    {
        var message = new Message
        {
            Content = content,
            UserId = userId,
            ChannelId = channelId,
            Timestamp = DateTime.UtcNow
        };

        await _messageRepository.SaveMessageAsync(message);
    }
}
