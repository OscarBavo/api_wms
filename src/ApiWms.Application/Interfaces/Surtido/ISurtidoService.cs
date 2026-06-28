using ApiWms.Application.DTOs.Surtido;

namespace ApiWms.Application.Interfaces.Surtido;

public interface ISurtidoService
{
    Task<ObtenerLocalidadesResponseDto> ObtenerLocalidadesAsync(ObtenerLocalidadesRequestDto request);
    Task<ValidarArticuloResponseDto> ValidarArticuloAsync(ValidarArticuloRequestDto request);
    Task<ValidarArticuloSkuResponseDto> ValidarArticuloSkuAsync(ValidarArticuloSkuRequestDto request);
    Task<ValidarUbicacionTransitoWmsResponseDto> ValidarUbicacionTransitoWmsAsync(ValidarUbicacionTransitoWmsRequestDto request);
    Task<ValidarTransitoLocalidadWmsResponseDto> ValidarTransitoLocalidadWmsAsync(ValidarTransitoLocalidadWmsRequestDto request);
    Task<FinalizarTransitoLocalidadResponseDto> FinalizarTransitoLocalidadAsync(FinalizarTransitoLocalidadRequestDto request);
}
