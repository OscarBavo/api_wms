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
        parameters.Add("@pIdUsuario", idUsuario, DbType.Int32);
        parameters.Add("@pCodigoUbicacionesSurtidas", vCodigoUbicacionesSurtidas, DbType.String);

        using var multi = await connection.QueryMultipleAsync(
            "spRecoleccionObtenerLocalidad",
            parameters,
            commandType: CommandType.StoredProcedure);

        var localidad = await multi.ReadFirstOrDefaultAsync<Localidad>();
        var detalles = (await multi.ReadAsync<DetallePedido>()).ToList();

        return (localidad, detalles);
    }

    public async Task<List<ArticuloRecoleccion>> ValidarArticuloAsync(
        int pIdRecoleccion, int pIdOrdenEmbarque, int pIdLocalidad, int pIdUsuario, string pCodigoUbicacionesSurtidas)
    {
        using var connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@pIdRecoleccion", pIdRecoleccion, DbType.Int32);
        parameters.Add("@pIdOrdenEmbarque", pIdOrdenEmbarque, DbType.Int32);
        parameters.Add("@pIdLocalidad", pIdLocalidad, DbType.Int32);
        parameters.Add("@pIdUsuario", pIdUsuario, DbType.Int32);
        parameters.Add("@pCodigoUbicacionesSurtidas", pCodigoUbicacionesSurtidas, DbType.String);

        var result = await connection.QueryAsync<ArticuloRecoleccion>(
            "spRecoleccionObtenerArticulos",
            parameters,
            commandType: CommandType.StoredProcedure);

        return result.ToList();
    }

    public async Task<List<ArticuloSku>> ValidarArticuloSkuAsync(
        int pIdRecoleccion, int pIdLocalidad, string pCodigoSku, int pIdUsuario, string pCodigoUbicacionesSurtidas, int pIdOrdenEmbarque)
    {
        using var connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@pIdRecoleccion", pIdRecoleccion, DbType.Int32);
        parameters.Add("@pIdLocalidad", pIdLocalidad, DbType.Int32);
        parameters.Add("@pCodigoSku", pCodigoSku, DbType.String, size: 50);
        parameters.Add("@pIdUsuario", pIdUsuario, DbType.Int32);
        parameters.Add("@pCodigoUbicacionesSurtidas", pCodigoUbicacionesSurtidas, DbType.String);
        parameters.Add("@pIdOrdenEmbarque", pIdOrdenEmbarque, DbType.Int32);

        var result = await connection.QueryAsync<ArticuloSku>(
            "spRecoleccionValidarSKU",
            parameters,
            commandType: CommandType.StoredProcedure);

        return result.ToList();
    }
}
