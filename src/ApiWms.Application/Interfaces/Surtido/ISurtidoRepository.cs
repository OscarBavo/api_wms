using ApiWms.Domain.Entities.Surtido;

namespace ApiWms.Application.Interfaces.Surtido;

public interface ISurtidoRepository
{
    Task<(Localidad? Localidad, List<DetallePedido> Detalles)> ObtenerLocalidadesAsync(
        int idRecoleccion, int idUsuario, string vCodigoUbicacionesSurtidas);

    Task<List<ArticuloRecoleccion>> ValidarArticuloAsync(
        int pIdRecoleccion, int pIdOrdenEmbarque, int pIdLocalidad, int pIdUsuario, string pCodigoUbicacionesSurtidas);
}
