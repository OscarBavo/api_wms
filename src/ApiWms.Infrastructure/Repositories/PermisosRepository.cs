using ApiWms.Application.Interfaces.Permisos;
using ApiWms.Domain.Entities.Permisos;
using ApiWms.Infrastructure.Persistence;
using Dapper;
using System.Data;

namespace ApiWms.Infrastructure.Repositories;

public class PermisosRepository : IPermisosRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    public PermisosRepository(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<List<PermisoItem>> ConsultarPermisosAsync(int idUsuario, int tipoModulo)
    {
        using var connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@pIdUsuario", idUsuario, DbType.Int32);
        parameters.Add("@pTipoModulo", tipoModulo, DbType.Int32);

        var result = await connection.QueryAsync<PermisoItem>(
            "spPermisosConsultar",
            parameters,
            commandType: CommandType.StoredProcedure);

        return result.ToList();
    }
}
