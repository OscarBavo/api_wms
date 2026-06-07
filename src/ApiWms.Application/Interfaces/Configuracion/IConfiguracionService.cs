using ApiWms.Application.DTOs.Configuracion;

namespace ApiWms.Application.Interfaces.Configuracion;

public interface IConfiguracionService
{
    Task<List<ConfiguracionItemDto>> ConsultarConfiguracionAsync();
}
