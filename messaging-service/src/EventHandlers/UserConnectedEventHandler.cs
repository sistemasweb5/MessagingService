using MessagingService.src.Repositories;
using MessagingService.src.Events;
using MessagingService.src.Domain;

namespace MessagingService.src.EventHandlers;
public class UserConnectedEventHandler
{
    private readonly UserRepository _userRepository;

    public UserConnectedEventHandler(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async void Handle(UserConnectedEvent @event)
    {
        var user = await GetUserByEmail(@event.Username);
        if (user is null) return;
    }

    private async Task<User?> GetUserByEmail(string email)
    {
        return await _userRepository.GetUserByEmail(email);
    }

}
