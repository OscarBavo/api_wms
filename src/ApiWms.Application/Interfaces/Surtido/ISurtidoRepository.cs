using ApiWms.Application.DTOs.Surtido;
using ApiWms.Domain.Entities.Surtido;

namespace ApiWms.Application.Interfaces.Surtido;

public interface ISurtidoRepository
{
    Task<(Localidad? Localidad, List<DetallePedido> Detalles)> ObtenerLocalidadesAsync(
        int idRecoleccion, int idUsuario, string vCodigoUbicacionesSurtidas);

    Task<List<ArticuloRecoleccion>> ValidarArticuloAsync(
        int pIdRecoleccion, int pIdOrdenEmbarque, int pIdLocalidad, int pIdUsuario, string pCodigoUbicacionesSurtidas);

    Task<List<ArticuloSku>> ValidarArticuloSkuAsync(
        int pIdRecoleccion, int pIdLocalidad, string pCodigoSku, int pIdUsuario, string pCodigoUbicacionesSurtidas, int pIdOrdenEmbarque);

    Task<UbicacionTransitoResultado?> ValidarUbicacionTransitoWmsAsync(
        string pClaveLocalidad, int pIdUsuario, string pIdRecoleccionDetalle,
        string pModuloWMS, int pIdTipoUbicacion, int pIdIntercambio);

    Task<TransitoLocalidadWmsResultado?> ValidarTransitoLocalidadWmsAsync(ValidarTransitoLocalidadWmsRequestDto request);
    Task<FinalizarTransitoLocalidadResultado?> FinalizarTransitoLocalidadAsync(FinalizarTransitoLocalidadRequestDto request);
}
