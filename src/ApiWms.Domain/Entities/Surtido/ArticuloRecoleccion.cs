namespace ApiWms.Domain.Entities.Surtido;

public class ArticuloRecoleccion
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
