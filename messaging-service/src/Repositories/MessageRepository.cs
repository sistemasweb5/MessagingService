using MessagingService.src.Domain;
using MongoDB.Driver;

namespace MessagingService.src.Repositories;

public class MessageRepository : BaseRepository<Message>
{
    public MessageRepository(IMongoDatabase database) : base(database, "Messages") { }

    public async Task<List<Message>> GetByChannelIdAsync(Guid channelId)
    {
        var filter = Builders<Message>.Filter.Eq(m => m.ChannelId, channelId);
        return await _collection.Find(filter).ToListAsync();
    }
}