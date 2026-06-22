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
        try
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
        catch (Exception ex)
        {
            // Aquí podrías loguear el error si tienes un sistema de logging
            return new LoginResponseDto
            {
                Exito = false,
                Mensaje = $"Error al iniciar sesión: {ex.Message}"
            };
        }
    }

    public async Task<ConexionResponseDto> ValidarConexionAsync()
    {
        var conectado = await _authRepository.ValidarConexionAsync();

        if (conectado)
            return new ConexionResponseDto { Code = 200, Respuesta = "Conexión correcta", Estatus = "estable" };

        return new ConexionResponseDto { Code = 401, Respuesta = "No se puede conectar", Estatus = "sin conexión" };
    }

    public async Task<AgregarSesionResponseDto> AgregarSesionAsync(AgregarSesionRequestDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Modulo) ||
            string.IsNullOrWhiteSpace(request.TipoAccion) ||
            request.IdUsuario is null)
        {
            return new AgregarSesionResponseDto { Code = -1, Response = "no info", Status = 0 };
        }

        try
        {
            var resultado = await _authRepository.AgregarSesionAsync(request);

            if (resultado?.Resultado == "OK")
                return new AgregarSesionResponseDto { Code = 1, Response = "Sesión modificada", Status = 200 };

            return new AgregarSesionResponseDto { Code = -1, Response = "Error SP", Status = 400 };
        }
        catch
        {
            return new AgregarSesionResponseDto { Code = -1, Response = "Error SP", Status = 400 };
        }
    }
}
