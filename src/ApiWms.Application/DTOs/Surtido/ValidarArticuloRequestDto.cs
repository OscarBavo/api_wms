using System.ComponentModel.DataAnnotations;

namespace ApiWms.Application.DTOs.Surtido;

public class ValidarArticuloRequestDto
{
    [Required(ErrorMessage = "pIdRecoleccion es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "pIdRecoleccion debe ser mayor a cero.")]
    public int? pIdRecoleccion { get; set; }

    [Required(ErrorMessage = "pIdOrdenEmbarque es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "pIdOrdenEmbarque debe ser mayor a cero.")]
    public int? pIdOrdenEmbarque { get; set; }

    [Required(ErrorMessage = "pIdLocalidad es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "pIdLocalidad debe ser mayor a cero.")]
    public int? pIdLocalidad { get; set; }

    [Required(ErrorMessage = "pIdUsuario es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "pIdUsuario debe ser mayor a cero.")]
    public int? pIdUsuario { get; set; }

    public string pCodigoUbicacionesSurtidas { get; set; } = string.Empty;
}
