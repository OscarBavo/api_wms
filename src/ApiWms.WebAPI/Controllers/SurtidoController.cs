using ApiWms.Application.DTOs.Surtido;
using ApiWms.Application.Interfaces.Surtido;
using Microsoft.AspNetCore.Mvc;

namespace ApiWms.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SurtidoController : ControllerBase
{
    private readonly ISurtidoService _surtidoService;

    public SurtidoController(ISurtidoService surtidoService)
    {
        _surtidoService = surtidoService;
    }

    /// <summary>Valida un artículo por SKU en la recolección</summary>
    [HttpPost("validar-articulo-sku")]
    [ProducesResponseType(typeof(ValidarArticuloSkuResponseDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> ValidarArticuloSku([FromBody] ValidarArticuloSkuRequestDto request)
    {
        if (!ModelState.IsValid)
            return Ok(new ValidarArticuloSkuResponseDto { Code = -1, Response = "no info", Status = 0 });

        var resultado = await _surtidoService.ValidarArticuloSkuAsync(request);
        return Ok(resultado);
    }

    /// <summary>Valida y obtiene artículos de recolección para surtido</summary>
    [HttpPost("validar-articulo")]
    [ProducesResponseType(typeof(ValidarArticuloResponseDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> ValidarArticulo([FromBody] ValidarArticuloRequestDto request)
    {
        if (!ModelState.IsValid)
            return Ok(new ValidarArticuloResponseDto { Code = -1, Response = "no info", Status = 0 });

        var resultado = await _surtidoService.ValidarArticuloAsync(request);
        return Ok(resultado);
    }

    /// <summary>Obtiene las localidades de recolección para surtido</summary>
    [HttpPost("obtener-localidades")]
    [ProducesResponseType(typeof(ObtenerLocalidadesResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ObtenerLocalidades([FromBody] ObtenerLocalidadesRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var resultado = await _surtidoService.ObtenerLocalidadesAsync(request);
        return Ok(resultado);
    }

    /// <summary>Valida la ubicación de tránsito WMS en la recolección</summary>
    [HttpPost("validar-ubicacion-transito-wms")]
    [ProducesResponseType(typeof(ValidarUbicacionTransitoWmsResponseDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> ValidarUbicacionTransitoWms([FromBody] ValidarUbicacionTransitoWmsRequestDto request)
    {
        if (!ModelState.IsValid)
            return Ok(new ValidarUbicacionTransitoWmsResponseDto { Code = -1, Response = "no info", Status = 0 });

        var resultado = await _surtidoService.ValidarUbicacionTransitoWmsAsync(request);
        return Ok(resultado);
    }

    /// <summary>Valida el tránsito de localidad WMS en la recolección</summary>
    [HttpPost("validar-transito-localidad-wms")]
    [ProducesResponseType(typeof(ValidarTransitoLocalidadWmsResponseDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> ValidarTransitoLocalidadWms([FromBody] ValidarTransitoLocalidadWmsRequestDto request)
    {
        if (!ModelState.IsValid)
            return Ok(new ValidarTransitoLocalidadWmsResponseDto { Code = -1, Response = "no info", Status = 0 });

        var resultado = await _surtidoService.ValidarTransitoLocalidadWmsAsync(request);
        return Ok(resultado);
    }

    /// <summary>Finaliza el movimiento de tránsito de localidad en la recolección</summary>
    [HttpPost("finalizar-transito-localidad")]
    [ProducesResponseType(typeof(FinalizarTransitoLocalidadResponseDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> FinalizarTransitoLocalidad([FromBody] FinalizarTransitoLocalidadRequestDto request)
    {
        if (!ModelState.IsValid)
            return Ok(new FinalizarTransitoLocalidadResponseDto { Code = -1, Response = "no info", Status = 0 });

        var resultado = await _surtidoService.FinalizarTransitoLocalidadAsync(request);
        return Ok(resultado);
    }
}
