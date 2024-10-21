using System.Data;

namespace PostgresWithDapper.Data;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnectionAsync();
}
