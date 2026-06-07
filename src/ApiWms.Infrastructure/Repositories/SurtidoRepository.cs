using ApiWms.Application.Interfaces.Surtido;
using ApiWms.Domain.Entities.Surtido;
using ApiWms.Infrastructure.Persistence;
using Dapper;
using System.Data;

namespace ApiWms.Infrastructure.Repositories;

public class SurtidoRepository : ISurtidoRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    public SurtidoRepository(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<(Localidad? Localidad, List<DetallePedido> Detalles)> ObtenerLocalidadesAsync(
        int idRecoleccion, int idUsuario, string vCodigoUbicacionesSurtidas)
    {
        using var connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@pIdRecoleccion", idRecoleccion, DbType.Int32);
        parameters.Add("@IdUsuario", idUsuario, DbType.Int32);
        parameters.Add("@vCodigoUbicacionesSurtidas", vCodigoUbicacionesSurtidas, DbType.String);

        using var multi = await connection.QueryMultipleAsync(
            "spRecoleccionObtenerLocalidad",
            parameters,
            commandType: CommandType.StoredProcedure);

        var localidad = await multi.ReadFirstOrDefaultAsync<Localidad>();
        var detalles = (await multi.ReadAsync<DetallePedido>()).ToList();

        return (localidad, detalles);
    }
}
