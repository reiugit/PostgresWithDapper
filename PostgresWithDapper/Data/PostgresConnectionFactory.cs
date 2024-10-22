using Npgsql;
using System.Data;

namespace PostgresWithDapper.Data;

public class PostgresConnectionFactory(string connectionString) : IDbConnectionFactory
{
    public async Task<IDbConnection> CreateConnectionAsync()
    {
        var connection = new NpgsqlConnection(connectionString);

        try
        {
            await connection.OpenAsync();
        }
        catch (Exception ex)
        {
            connection.Dispose();
            throw new Exception("Could not open a connection to the database", ex);
        }
        
        return connection;
    }
}
