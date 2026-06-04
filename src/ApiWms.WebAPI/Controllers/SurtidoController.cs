using ApiWms.Application.DTOs.Surtido;
using ApiWms.Application.Interfaces.Surtido;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiWms.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SurtidoController : ControllerBase
{
    private readonly ISurtidoService _surtidoService;

    public SurtidoController(ISurtidoService surtidoService)
    {
        _surtidoService = surtidoService;
    }

    /// <summary>Obtiene las localidades de recolección para surtido</summary>
    /// <remarks>Requiere token JWT en el header Authorization: Bearer {token}</remarks>
    [HttpPost("obtener-localidades")]
    [ProducesResponseType(typeof(ObtenerLocalidadesResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> ObtenerLocalidades([FromBody] ObtenerLocalidadesRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var resultado = await _surtidoService.ObtenerLocalidadesAsync(request);
        return Ok(resultado);
    }
}
