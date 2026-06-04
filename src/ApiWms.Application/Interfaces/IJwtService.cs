using ApiWms.Application.DTOs;

namespace ApiWms.Application.Interfaces;

public interface IJwtService
{
    string GenerarToken(DatosUsuarioDto usuario);
}
