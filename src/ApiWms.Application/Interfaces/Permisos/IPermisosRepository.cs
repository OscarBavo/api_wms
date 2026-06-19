using ApiWms.Domain.Entities.Permisos;

namespace ApiWms.Application.Interfaces.Permisos;

public interface IPermisosRepository
{
    Task<List<PermisoItem>> ConsultarPermisosAsync(int idUsuario, string tipoModulo);
}
