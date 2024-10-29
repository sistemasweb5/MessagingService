using System.Data;

namespace MessagingService.src.Data.Interfaces;

public interface IDbConnectionSingleton 
{
    Task<IDbConnection> CreateConnectionAsync();
}
