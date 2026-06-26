namespace ApiWms.Application.DTOs.Surtido;

public class ValidarArticuloSkuResponseDto
{
    public int Code { get; set; }
    public string Response { get; set; } = string.Empty;
    public int Status { get; set; }
    public List<ArticuloSkuDto>? RecoleccionArticuloDatos { get; set; }
}

public class ArticuloSkuDto
{
    public string ClaveArticulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public double Cantidad { get; set; }
    public String Unidad { get; set; }
    public double MultiploCaja { get; set; }
    public int IdOrdenEmbarque { get; set; }
    public string NumPedido { get; set; } = string.Empty;
    public int IdLocalidadTransito { get; set; }
    public string CodigoLocalidadTransito { get; set; } = string.Empty;
    public string LeyendaSurtido { get; set; } = string.Empty;
    public int SinCodigoBarras { get; set; }
    public string ForzarLeyendaSurtido { get; set; } = string.Empty;
    public bool ValorAgregado { get; set; }
    public bool ManejoLote { get; set; }
    public bool ManejoSerie { get; set; }
    public string Lote { get; set; } = string.Empty;
    public string Presentacion { get; set; } = string.Empty;
    public string MultPresentacion { get; set; } = string.Empty;
    public double Sugerencia { get; set; }
    public bool Consolidacion { get; set; }
}
