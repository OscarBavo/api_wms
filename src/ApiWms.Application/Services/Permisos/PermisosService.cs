using ApiWms.Application.DTOs.Permisos;
using ApiWms.Application.Interfaces.Permisos;

namespace ApiWms.Application.Services.Permisos;

public class PermisosService : IPermisosService
{
    private readonly IPermisosRepository _permisosRepository;

    public PermisosService(IPermisosRepository permisosRepository)
    {
        _permisosRepository = permisosRepository;
    }

    public async Task<PermisosResponseDto> ConsultarPermisosAsync(PermisosRequestDto request)
    {
        try
        {
            var permisos = await _permisosRepository.ConsultarPermisosAsync(request.IdUsuario, request.TipoModulo);

            return new PermisosResponseDto
            {
                Code = 200,
                Response = "OK",
                Status = "Estable",
                Permisos = permisos.Select(p => new PermisoItemDto
                {
                    IdModulo = p.IdModulo,
                    NombreModulo = p.NombreModulo,
                    Consultar = p.Consultar
                }).ToList()
            };
        }
        catch
        {
            return new PermisosResponseDto
            {
                Code = 400,
                Response = "No conexión",
                Status = "No estable",
                Permisos = []
            };
        }
    }
}
