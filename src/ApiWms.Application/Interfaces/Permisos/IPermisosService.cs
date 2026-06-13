using ApiWms.Application.DTOs.Permisos;

namespace ApiWms.Application.Interfaces.Permisos;

public interface IPermisosService
{
    Task<PermisosResponseDto> ConsultarPermisosAsync(PermisosRequestDto request);
}
