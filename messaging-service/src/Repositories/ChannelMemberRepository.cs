using MessagingService.src.Domain;
using MongoDB.Driver;

namespace MessagingService.src.Repositories;

public class ChannelMemberRepository : BaseRepository<ChannelMember>
{
    public ChannelMemberRepository(IMongoDatabase database) : base(database, "ChannelMembers") { }

    public async Task<List<ChannelMember>> GetByChannelIdAsync(Guid channelId)
    {
        var filter = Builders<ChannelMember>.Filter.Eq(cm => cm.ChannelID, channelId);
        return await _collection.Find(filter).ToListAsync();
    }

    public async Task<List<ChannelMember>> GetByUserIdAsync(Guid userId)
    {
        var filter = Builders<ChannelMember>.Filter.Eq(cm => cm.UserID, userId);
        return await _collection.Find(filter).ToListAsync();
    }
}

