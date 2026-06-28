using System.ComponentModel.DataAnnotations;

namespace ApiWms.Application.DTOs.Surtido;

public class ValidarTransitoLocalidadWmsRequestDto
{
    [Required(ErrorMessage = "idRecoleccion es obligatorio.")]
    public int? IdRecoleccion { get; set; }

    [Required(ErrorMessage = "idOrdenEmbarque es obligatorio.")]
    public int? IdOrdenEmbarque { get; set; }

    [Required(ErrorMessage = "claveLocalidadOrigen es obligatorio.")]
    [MaxLength(15, ErrorMessage = "claveLocalidadOrigen no puede exceder 15 caracteres.")]
    public string? ClaveLocalidadOrigen { get; set; }

    [Required(ErrorMessage = "claveLocalidadDestino es obligatorio.")]
    [MaxLength(15, ErrorMessage = "claveLocalidadDestino no puede exceder 15 caracteres.")]
    public string? ClaveLocalidadDestino { get; set; }

    [Required(ErrorMessage = "codigoSKU es obligatorio.")]
    [MaxLength(50, ErrorMessage = "codigoSKU no puede exceder 50 caracteres.")]
    public string? CodigoSKU { get; set; }

    [Required(ErrorMessage = "cantidad es obligatorio.")]
    public decimal? Cantidad { get; set; }

    [Required(ErrorMessage = "idUsuario es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "idUsuario debe ser mayor a cero.")]
    public int? IdUsuario { get; set; }

    [MaxLength(36, ErrorMessage = "lote no puede exceder 36 caracteres.")]
    public string? Lote { get; set; }

    public string? Series { get; set; }

    public string ModuloWMS { get; set; } = "Surtido";

    public int? IdIntercambio { get; set; }

    public int? TipoSurtido { get; set; }
}
