using ApiWms.Domain.Entities.Configuracion;

namespace ApiWms.Application.Interfaces.Configuracion;

public interface IConfiguracionRepository
{
    Task<List<ConfiguracionItem>> ConsultarConfiguracionAsync();
}
