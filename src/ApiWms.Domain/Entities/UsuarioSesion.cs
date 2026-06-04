namespace ApiWms.Domain.Entities;

public class UsuarioSesion
{
    public int IdUsuario { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int IdPerfil { get; set; }
    public int IDTIPOUSUARIO { get; set; }
    public string Resultado { get; set; } = string.Empty;
}
