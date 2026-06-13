using ApiWms.Application.DTOs;

namespace ApiWms.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    Task<ConexionResponseDto> ValidarConexionAsync();
}
