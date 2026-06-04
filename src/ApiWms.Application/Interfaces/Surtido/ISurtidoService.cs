using ApiWms.Application.DTOs.Surtido;

namespace ApiWms.Application.Interfaces.Surtido;

public interface ISurtidoService
{
    Task<ObtenerLocalidadesResponseDto> ObtenerLocalidadesAsync(ObtenerLocalidadesRequestDto request);
}
