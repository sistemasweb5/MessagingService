using MessagingService.src.Domain;
using MongoDB.Driver;

namespace MessagingService.src.Repositories;

public class UserRepository : BaseRepository<User>
{
    public UserRepository(IMongoDatabase database) : base(database, "Users") { }

    public async Task<User?> GetById(Guid userId)
    {
        return await _collection.Find(user => user.UserId == userId).FirstOrDefaultAsync();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _collection.Find(user => user.Email == email).FirstOrDefaultAsync();
    }
}
