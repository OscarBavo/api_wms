namespace ApiWms.Application.DTOs;

public class LoginResponseDto
{
    public bool Exito { get; set; }
    public string Mensaje { get; set; } = string.Empty;
    public string? Token { get; set; }
    public DatosUsuarioDto? Datos { get; set; }
}

public class DatosUsuarioDto
{
    public int IdUsuario { get; set; }
    public string Usuario { get; set; } = string.Empty;
    public string NombreCompleto { get; set; } = string.Empty;
    public string Perfil { get; set; } = string.Empty;
    public int? IdAlmacen { get; set; }
    public string? Almacen { get; set; }
}
