using ApiWms.Application.DTOs;
using ApiWms.Domain.Entities;

namespace ApiWms.Application.Interfaces;

public interface IAuthRepository
{
    Task<UsuarioSesion?> IniciarSesionAsync(LoginRequestDto request);
    Task<bool> ValidarConexionAsync();
}
