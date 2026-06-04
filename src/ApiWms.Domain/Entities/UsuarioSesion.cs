namespace ApiWms.Domain.Entities;

public class UsuarioSesion
{
    public int Resultado { get; set; }
    public string Mensaje { get; set; } = string.Empty;
    public int? IdUsuario { get; set; }
    public string? Usuario { get; set; }
    public string? NombreCompleto { get; set; }
    public string? Perfil { get; set; }
    public int? IdAlmacen { get; set; }
    public string? Almacen { get; set; }
}
