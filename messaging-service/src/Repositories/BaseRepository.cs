using MongoDB.Driver;

namespace MessagingService.src.Repositories;

public abstract class BaseRepository<T>
{
    protected readonly IMongoCollection<T> _collection;

    protected BaseRepository(IMongoDatabase database, string collectionName)
    {
        _collection = database.GetCollection<T>(collectionName);
    }

    public async Task InsertAsync(T entity) => await _collection.InsertOneAsync(entity);

    public async Task<List<T>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

    public async Task<T> GetByIdAsync(Guid id) => await _collection.Find(Builders<T>.Filter.Eq("Id", id)).FirstOrDefaultAsync();

    public async Task UpdateAsync(Guid id, T entity) => await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("Id", id), entity);

    public async Task DeleteAsync(Guid id) => await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));
}

