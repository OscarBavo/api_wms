using ApiWms.Application.DTOs;
using ApiWms.Application.Interfaces;
using ApiWms.Domain.Entities;
using ApiWms.Infrastructure.Persistence;
using Dapper;
using System.Data;

namespace ApiWms.Infrastructure.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly SqlConnectionFactory _connectionFactory;

    public AuthRepository(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<UsuarioSesion?> IniciarSesionAsync(LoginRequestDto request)
    {
        using var connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@pUsuario", request.Usuario, DbType.String, size: 50);
        parameters.Add("@pPassword", request.Password, DbType.String, size: 50);
        parameters.Add("@pMACADDRESS", request.MacAddress, DbType.String, size: 50);
        parameters.Add("@pNumeroSerie", request.NumeroSerie, DbType.String, size: 50);
        parameters.Add("@pModeloTerminal", request.ModeloTerminal, DbType.String, size: 50);
        parameters.Add("@pVERSIONWMS", request.VersionWms, DbType.String, size: 50);
        parameters.Add("@pNumCompilacion", request.compilacion, DbType.String, size: 150);

        /**
         * 	@pUsuario VARCHAR(50),
	@pPassword VARCHAR(50),
	@pMACADDRESS VARCHAR(50),
	@pNumeroSerie VARCHAR(50),
	@pModeloTerminal VARCHAR(50),
	@pVERSIONWMS  VARCHAR(50) ,
	@pNumCompilacion VARCHAR(150)
        **/


        return await connection.QueryFirstOrDefaultAsync<UsuarioSesion>(
            "spIniciarSesionMovil",
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> ValidarConexionAsync()
    {
        try
        {
            using var connection = _connectionFactory.CreateConnection();
            await connection.OpenAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<SesionResultado?> AgregarSesionAsync(AgregarSesionRequestDto request)
    {
        using var connection = _connectionFactory.CreateConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@pModulo", request.Modulo, DbType.String, size: 100);
        parameters.Add("@pTipoAccion", request.TipoAccion, DbType.String, size: 100);
        parameters.Add("@pIdUsuario", request.IdUsuario, DbType.Int32);

        return await connection.QueryFirstOrDefaultAsync<SesionResultado>(
            "spSesionAgregar",
            parameters,
            commandType: CommandType.StoredProcedure);
    }
}
