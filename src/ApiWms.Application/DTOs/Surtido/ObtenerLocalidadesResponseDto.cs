namespace ApiWms.Application.DTOs.Surtido;

public class ObtenerLocalidadesResponseDto
{
    public int Code { get; set; }
    public string Response { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public LocalidadDto? Localidad { get; set; }
    public List<DetallePedidoDto> Detalles { get; set; } = new();
}

public class LocalidadDto
{
    public string CodigoLocalidad { get; set; } = string.Empty;
    public int IdLocalidad { get; set; }
    public int IdOrdenEmbarque { get; set; }
    public string Mov { get; set; } = string.Empty;
    public string NumPedido { get; set; } = string.Empty;
    public int IdRecoleccion { get; set; }
    public int Surtido { get; set; }
    public int IdTipoLocalidad { get; set; }
    public int TipoLocalidad { get; set; }
    public float CantRecolectada { get; set; }
    public int TipoSurtido { get; set; }
    public bool Finalizar { get; set; }
    public string Detalle { get; set; } = string.Empty;
    public int IdArea { get; set; }
}

public class DetallePedidoDto
{
    public string NumPedido { get; set; } = string.Empty;
    public string Clave { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Cantidad { get; set; } = string.Empty;
    public string Unidad { get; set; } = string.Empty;
    public string Comentarios { get; set; } = string.Empty;
    public bool ConteoVerificacionStock { get; set; }
}
