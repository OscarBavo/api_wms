namespace ApiWms.Application.DTOs.Permisos;

public class PermisosResponseDto
{
    public int Code { get; set; }
    public string Response { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public List<PermisoItemDto> Permisos { get; set; } = [];
}

public class PermisoItemDto
{
    public int IdModulo { get; set; }
    public string NombreModulo { get; set; } = string.Empty;
    public bool Consultar { get; set; }
}
