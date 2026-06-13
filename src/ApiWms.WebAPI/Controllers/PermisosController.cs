using ApiWms.Application.DTOs.Permisos;
using ApiWms.Application.Interfaces.Permisos;
using Microsoft.AspNetCore.Mvc;

namespace ApiWms.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermisosController : ControllerBase
{
    private readonly IPermisosService _permisosService;

    public PermisosController(IPermisosService permisosService)
    {
        _permisosService = permisosService;
    }

    /// <summary>Consulta los permisos de un usuario por tipo de módulo</summary>
    [HttpPost]
    [ProducesResponseType(typeof(PermisosResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(PermisosResponseDto), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConsultarPermisos([FromBody] PermisosRequestDto request)
    {
        var resultado = await _permisosService.ConsultarPermisosAsync(request);

        if (resultado.Code == 400)
            return BadRequest(resultado);

        return Ok(resultado);
    }
}
