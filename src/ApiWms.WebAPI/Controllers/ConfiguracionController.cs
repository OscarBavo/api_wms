using ApiWms.Application.DTOs.Configuracion;
using ApiWms.Application.Interfaces.Configuracion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiWms.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ConfiguracionController : ControllerBase
{
    private readonly IConfiguracionService _configuracionService;

    public ConfiguracionController(IConfiguracionService configuracionService)
    {
        _configuracionService = configuracionService;
    }

    [HttpGet("ConsultaConfiguracion")]
    [ProducesResponseType(typeof(List<ConfiguracionItemDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetConsultaConfiguracion()
    {
        var resultado = await _configuracionService.ConsultarConfiguracionAsync();
        return Ok(resultado);
    }
}
