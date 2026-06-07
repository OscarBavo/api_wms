using ApiWms.Application.Interfaces.Configuracion;
using ApiWms.Domain.Entities.Configuracion;
using ApiWms.Infrastructure.Persistence;
using Dapper;
using System.Data;

namespace ApiWms.Infrastructure.Repositories;

public class ConfiguracionRepository : IConfiguracionRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    public ConfiguracionRepository(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<List<ConfiguracionItem>> ConsultarConfiguracionAsync()
    {
        using var connection = _connectionFactory.CreateConnection();

        var resultado = await connection.QueryAsync<ConfiguracionItem>(
            "spConfiguracionConsultar",
            commandType: CommandType.StoredProcedure);

        return resultado.ToList();
    }
}
