namespace ApiWms.Application.DTOs.Surtido;

public class ValidarArticuloResponseDto
{
    public int Code { get; set; }
    public string Response { get; set; } = string.Empty;
    public int Status { get; set; }
    public List<ArticuloRecoleccionDto>? RecoleccionDatos { get; set; }
}

public class ArticuloRecoleccionDto
{
    public int IdRecoleccion { get; set; }
    public int IdOrdenEmbarque { get; set; }
    public string NumPedido { get; set; } = string.Empty;
    public int IdLocalidad { get; set; }
    public int IdEstilo { get; set; }
    public string Articulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public int MultiploCaja { get; set; }
    public string LeyendaSurtido { get; set; } = string.Empty;
    public int SinCodigoBarras { get; set; }
    public string Lote { get; set; } = string.Empty;
    public double CantPresentacion { get; set; }
    public string NombrePresentacion { get; set; } = string.Empty;
    public double CantidadSurtir { get; set; }
}
