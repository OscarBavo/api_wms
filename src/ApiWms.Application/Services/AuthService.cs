using ApiWms.Application.DTOs;
using ApiWms.Application.Interfaces;

namespace ApiWms.Application.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly IJwtService _jwtService;

    public AuthService(IAuthRepository authRepository, IJwtService jwtService)
    {
        _authRepository = authRepository;
        _jwtService = jwtService;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
    {
        var sesion = await _authRepository.IniciarSesionAsync(request);

        if (sesion == null || sesion.Resultado != 0)
        {
            return new LoginResponseDto
            {
                Exito = false,
                Mensaje = sesion?.Mensaje ?? "Error al iniciar sesión."
            };
        }

        var datos = new DatosUsuarioDto
        {
            IdUsuario = sesion.IdUsuario ?? 0,
            Usuario = sesion.Usuario ?? string.Empty,
            NombreCompleto = sesion.NombreCompleto ?? string.Empty,
            Perfil = sesion.Perfil ?? string.Empty,
            IdAlmacen = sesion.IdAlmacen,
            Almacen = sesion.Almacen
        };

        var token = _jwtService.GenerarToken(datos);

        return new LoginResponseDto
        {
            Exito = true,
            Mensaje = sesion.Mensaje,
            Token = token,
            Datos = datos
        };
    }
}
