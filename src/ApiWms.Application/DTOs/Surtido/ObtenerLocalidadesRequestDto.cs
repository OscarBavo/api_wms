using System.ComponentModel.DataAnnotations;

namespace ApiWms.Application.DTOs.Surtido;

public class ObtenerLocalidadesRequestDto
{
    [Required(ErrorMessage = "IdRecoleccion es obligatorio.")]
    [Range(0, int.MaxValue, ErrorMessage = "IdRecoleccion debe ser mayor o igual a cero.")]
    public int? IdRecoleccion { get; set; }

    [Required(ErrorMessage = "IdUsuario es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "IdUsuario debe ser mayor a cero.")]
    public int? IdUsuario { get; set; }

    public string vCodigoUbicacionesSurtidas { get; set; } = string.Empty;
}
