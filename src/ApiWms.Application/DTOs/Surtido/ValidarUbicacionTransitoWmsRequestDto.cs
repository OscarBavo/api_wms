using System.ComponentModel.DataAnnotations;

namespace ApiWms.Application.DTOs.Surtido;

public class ValidarUbicacionTransitoWmsRequestDto
{
    [Required(ErrorMessage = "pClaveLocalidad es obligatorio.")]
    public string? pClaveLocalidad { get; set; }

    [Required(ErrorMessage = "pIdUsuario es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "pIdUsuario debe ser mayor a cero.")]
    public int? pIdUsuario { get; set; }

    [Required(ErrorMessage = "pIdRecoleccionDetalle es obligatorio.")]
    public string? pIdRecoleccionDetalle { get; set; }

    [Required(ErrorMessage = "pModuloWMS es obligatorio.")]
    [MaxLength(50, ErrorMessage = "pModuloWMS no puede exceder 50 caracteres.")]
    public string? pModuloWMS { get; set; }

    [Required(ErrorMessage = "pIdTipoUbicacion es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "pIdTipoUbicacion debe ser mayor a cero.")]
    public int? pIdTipoUbicacion { get; set; }

    [Required(ErrorMessage = "pIdIntercambio es obligatorio.")]
    [Range(0, int.MaxValue, ErrorMessage = "pIdIntercambio debe ser mayor o igual a cero.")]
    public int? pIdIntercambio { get; set; }
}
