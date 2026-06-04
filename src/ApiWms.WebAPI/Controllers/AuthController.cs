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
    /// <remarks>
    /// Llama al procedimiento almacenado spIniciarSesionMovilV2 y devuelve un token JWT.
    /// </remarks>
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
}
