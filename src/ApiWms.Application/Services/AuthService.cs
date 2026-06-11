using ApiWms.Application.DTOs;
using ApiWms.Application.Interfaces;

namespace ApiWms.Application.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;

    public AuthService(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
    {
        var sesion = await _authRepository.IniciarSesionAsync(request);

        if (sesion == null || sesion.Resultado != "OK")
        {
            return new LoginResponseDto
            {
                Exito = false,
                Mensaje = "Usuario o contraseña incorrectos."
            };
        }

        var datos = new DatosUsuarioDto
        {
            IdUsuario = sesion.IdUsuario,
            Nombre = sesion.Nombre,
            IdPerfil = sesion.IdPerfil,
            IdTipoUsuario = sesion.IDTIPOUSUARIO
        };

        return new LoginResponseDto
        {
            Exito = true,
            Mensaje = "Sesión iniciada correctamente.",
            Datos = datos
        };
    }
}
