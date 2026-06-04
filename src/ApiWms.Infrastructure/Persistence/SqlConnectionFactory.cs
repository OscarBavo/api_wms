using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ApiWms.Infrastructure.Persistence;

public class SqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' no encontrada.");
    }

    public SqlConnection CreateConnection() => new(_connectionString);
}
