using ApiWms.Application.DTOs.Configuracion;
using ApiWms.Application.Interfaces.Configuracion;

namespace ApiWms.Application.Services.Configuracion;

public class ConfiguracionService : IConfiguracionService
{
    private readonly IConfiguracionRepository _configuracionRepository;

    private static readonly HashSet<string> _categoriasExcluidas = new(StringComparer.OrdinalIgnoreCase)
    {
        "Alertas",
        "Correo",
        "Productividad",
        "Administración Órdenes Salida",
        "Catálogo Artículos",
        "Administración Órdenes Entrada",
        "Ajustes",
        "Catálogo Clientes",
        "Ubicaciones"
    };

    public ConfiguracionService(IConfiguracionRepository configuracionRepository)
    {
        _configuracionRepository = configuracionRepository;
    }

    public async Task<List<ConfiguracionItemDto>> ConsultarConfiguracionAsync()
    {
        var items = await _configuracionRepository.ConsultarConfiguracionAsync();

        return items
            .Where(i => !_categoriasExcluidas.Contains(i.Categoria))
            .Select(i => new ConfiguracionItemDto
            {
                Nombre = i.Nombre,
                Valor = i.Valor,
                Categoria = i.Categoria
            })
            .ToList();
    }
}
