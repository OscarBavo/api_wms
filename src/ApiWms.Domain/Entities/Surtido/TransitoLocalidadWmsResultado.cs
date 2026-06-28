namespace ApiWms.Domain.Entities.Surtido;

public class TransitoLocalidadWmsResultado
{
    public string Validacion { get; set; } = string.Empty;
    public string Cantidad { get; set; } = string.Empty;
    public string Unidad { get; set; } = string.Empty;
    public int IdLocalidad { get; set; }
    public string CodigoLocalidad { get; set; } = string.Empty;
    public string Mensaje { get; set; } = string.Empty;
    public string Resultado { get; set; } = string.Empty;
}
