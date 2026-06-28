using ApiWms.Application.DTOs.Surtido;
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

    public async Task<UbicacionTransitoResultado?> ValidarUbicacionTransitoWmsAsync(
        string pClaveLocalidad, int pIdUsuario, string pIdRecoleccionDetalle,
        string pModuloWMS, int pIdTipoUbicacion, int pIdIntercambio)
    {
        using var connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@pClaveLocalidad", pClaveLocalidad, DbType.String);
        parameters.Add("@pIdUsuario", pIdUsuario, DbType.Int32);
        parameters.Add("@pIdRecoleccionDetalle", pIdRecoleccionDetalle, DbType.String);
        parameters.Add("@pModuloWMS", pModuloWMS, DbType.String, size: 50);
        parameters.Add("@pIdTipoUbicacion", pIdTipoUbicacion, DbType.Int32);
        parameters.Add("@pIdIntercambio", pIdIntercambio, DbType.Int32);
        parameters.Add("@pResultado", dbType: DbType.String, size: 50, direction: ParameterDirection.Output);
        parameters.Add("@pMensaje", dbType: DbType.String, size: 50, direction: ParameterDirection.Output);

        var result = await connection.QueryFirstOrDefaultAsync<UbicacionTransitoResultado>(
            "spRecoleccionValidarUbicacionValidarWMS",
            parameters,
            commandType: CommandType.StoredProcedure);

        if (result != null)
            return result;

        var resultadoOutput = parameters.Get<string?>("@pResultado") ?? string.Empty;
        var mensajeOutput = parameters.Get<string?>("@pMensaje") ?? string.Empty;

        if (!string.IsNullOrWhiteSpace(resultadoOutput) || !string.IsNullOrWhiteSpace(mensajeOutput))
            return new UbicacionTransitoResultado { Resultado = resultadoOutput, Mensaje = mensajeOutput };

        return null;
    }

    public async Task<TransitoLocalidadWmsResultado?> ValidarTransitoLocalidadWmsAsync(ValidarTransitoLocalidadWmsRequestDto request)
    {
        using var connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@pIdRecoleccion", request.IdRecoleccion, DbType.Int32);
        parameters.Add("@pIdOrdenEmbarque", request.IdOrdenEmbarque, DbType.Int32);
        parameters.Add("@pClaveLocalidadOrigen", request.ClaveLocalidadOrigen, DbType.String, size: 15);
        parameters.Add("@pClaveLocalidadDestino", request.ClaveLocalidadDestino, DbType.String, size: 15);
        parameters.Add("@pCodigoSKU", request.CodigoSKU, DbType.String, size: 50);
        parameters.Add("@pCantidad", request.Cantidad, DbType.Decimal);
        parameters.Add("@pIdUsuario", request.IdUsuario, DbType.Int32);
        parameters.Add("@pLote", request.Lote, DbType.String, size: 36);
        parameters.Add("@pSerie", request.Series, DbType.String);
        parameters.Add("@pModuloWMS", request.ModuloWMS, DbType.String, size: 50);
        parameters.Add("@pIdIntercambio", request.IdIntercambio, DbType.Int32);
        parameters.Add("@pTipoSurtido", request.TipoSurtido, DbType.Int32);
        parameters.Add("@pResultado", dbType: DbType.String, size: 50, direction: ParameterDirection.Output);
        parameters.Add("@pMensaje", dbType: DbType.String, size: 50, direction: ParameterDirection.Output);

        var result = await connection.QueryFirstOrDefaultAsync<TransitoLocalidadWmsResultado>(
            "spRecoleccionValidarUbicacionTransitoValidarWMS",
            parameters,
            commandType: CommandType.StoredProcedure);

        if (result != null)
            return result;

        var resultadoOutput = parameters.Get<string?>("@pResultado") ?? string.Empty;
        var mensajeOutput = parameters.Get<string?>("@pMensaje") ?? string.Empty;

        if (!string.IsNullOrWhiteSpace(resultadoOutput) || !string.IsNullOrWhiteSpace(mensajeOutput))
            return new TransitoLocalidadWmsResultado { Resultado = resultadoOutput, Mensaje = mensajeOutput };

        return null;
    }

    public async Task<FinalizarTransitoLocalidadResultado?> FinalizarTransitoLocalidadAsync(FinalizarTransitoLocalidadRequestDto request)
    {
        using var connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@pIdRecoleccion", request.IdRecoleccion, DbType.Int32);
        parameters.Add("@pIdOrdenEmbarque", request.IdOrdenEmbarque, DbType.Int32);
        parameters.Add("@pClaveLocalidadOrigen", request.ClaveLocalidadOrigen, DbType.String, size: 15);
        parameters.Add("@pClaveLocalidadDestino", request.ClaveLocalidadDestino, DbType.String, size: 15);
        parameters.Add("@pCodigoSKU", request.CodigoSKU, DbType.String, size: 50);
        parameters.Add("@pCantidad", request.Cantidad?.ToString(), DbType.String, size: 100);
        parameters.Add("@pIdUsuario", request.IdUsuario, DbType.Int32);
        parameters.Add("@pLote", request.Lote, DbType.String, size: 36);
        parameters.Add("@pSerie", request.Series, DbType.String);
        parameters.Add("@pTipoSurtido", request.TipoSurtido, DbType.Int32);

        return await connection.QueryFirstOrDefaultAsync<FinalizarTransitoLocalidadResultado>(
            "spRecoleccionValidarUbicacionTransitoFinalizarMovimiento",
            parameters,
            commandType: CommandType.StoredProcedure);
    }
}
