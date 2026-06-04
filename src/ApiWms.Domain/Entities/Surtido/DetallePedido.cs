namespace ApiWms.Domain.Entities.Surtido;

public class DetallePedido
{
    public string NumPedido { get; set; } = string.Empty;
    public string Clave { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Cantidad { get; set; } = string.Empty;
    public string Unidad { get; set; } = string.Empty;
    public string Comentarios { get; set; } = string.Empty;
    public bool ConteoVerificacionStock { get; set; }
}
