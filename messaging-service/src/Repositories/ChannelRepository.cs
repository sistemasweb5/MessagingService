using MessagingService.src.Domain;
using MongoDB.Driver;

namespace MessagingService.src.Repositories;

public class ChannelRepository : BaseRepository<Channel>
{
    public ChannelRepository(IMongoDatabase database) : base(database, "Channels") { }

    public async Task<Channel> GetByChannelNameAsync(string channelName)
    {
        var filter = Builders<Channel>.Filter.Eq(c => c.ChannelName, channelName);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }
}

