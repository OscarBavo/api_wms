namespace ApiWms.Domain.Entities.Permisos;

public class PermisoItem
{
    public int IdModulo { get; set; }
    public string NombreModulo { get; set; } = string.Empty;
    public bool Consultar { get; set; }
}
