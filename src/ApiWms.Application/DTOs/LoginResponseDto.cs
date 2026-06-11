namespace ApiWms.Application.DTOs;

public class LoginResponseDto
{
    public bool Exito { get; set; }
    public string Mensaje { get; set; } = string.Empty;
    public DatosUsuarioDto? Datos { get; set; }
}

public class DatosUsuarioDto
{
    public int IdUsuario { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int IdPerfil { get; set; }
    public int IdTipoUsuario { get; set; }
}
