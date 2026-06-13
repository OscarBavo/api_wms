using ApiWms.Application.DTOs;
using ApiWms.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ApiWms.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>Inicia sesión en el sistema WMS Móvil</summary>
    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var resultado = await _authService.LoginAsync(request);

        if (!resultado.Exito)
            return Unauthorized(resultado);

        return Ok(resultado);
    }

    /// <summary>Valida la conexión con la base de datos SQL</summary>
    [HttpGet("validar-conexion")]
    [ProducesResponseType(typeof(ConexionResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ConexionResponseDto), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> ValidarConexion()
    {
        var resultado = await _authService.ValidarConexionAsync();

        if (resultado.Code == 200)
            return Ok(resultado);

        return Unauthorized(resultado);
    }
}
