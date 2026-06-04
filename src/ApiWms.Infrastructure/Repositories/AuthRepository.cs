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

        return await connection.QueryFirstOrDefaultAsync<UsuarioSesion>(
            "spIniciarSesionMovilV2",
            parameters,
            commandType: CommandType.StoredProcedure);
    }
}
