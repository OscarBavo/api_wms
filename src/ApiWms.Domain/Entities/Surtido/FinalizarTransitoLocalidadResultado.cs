namespace ApiWms.Domain.Entities.Surtido;

public class FinalizarTransitoLocalidadResultado
{
    public string Validacion { get; set; } = string.Empty;
    public decimal Cantidad { get; set; }
    public string Unidad { get; set; } = string.Empty;
    public int IdLocalidad { get; set; }
    public string CodigoLocalidad { get; set; } = string.Empty;
}
