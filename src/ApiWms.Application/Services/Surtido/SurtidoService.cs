using ApiWms.Application.DTOs.Surtido;
using ApiWms.Application.Interfaces.Surtido;

namespace ApiWms.Application.Services.Surtido;

public class SurtidoService : ISurtidoService
{
    private readonly ISurtidoRepository _surtidoRepository;

    public SurtidoService(ISurtidoRepository surtidoRepository)
    {
        _surtidoRepository = surtidoRepository;
    }

    public async Task<ObtenerLocalidadesResponseDto> ObtenerLocalidadesAsync(ObtenerLocalidadesRequestDto request)
    {
        var (localidad, detalles) = await _surtidoRepository.ObtenerLocalidadesAsync(
            request.IdRecoleccion!.Value,
            request.IdUsuario!.Value,
            request.vCodigoUbicacionesSurtidas);

        if (localidad == null)
        {
            return new ObtenerLocalidadesResponseDto
            {
                Code = -1,
                Response = "No se encontró información de localidad.",
                Status = "400"
            };
        }

        return new ObtenerLocalidadesResponseDto
        {
            Code = 1,
            Response = "OK",
            Status = "200",
            Localidad = new LocalidadDto
            {
                CodigoLocalidad = localidad.CODIGOLOCALIDAD,
                IdLocalidad = localidad.IDLOCALIDAD,
                IdOrdenEmbarque = localidad.IDORDENEMBARQUE,
                Mov = localidad.MOV,
                NumPedido = localidad.NUMPEDIDO,
                IdRecoleccion = localidad.IDRECOLECCION,
                Surtido = localidad.SURTIDO,
                IdTipoLocalidad = localidad.IDTIPOLOCALIDAD,
                TipoLocalidad = localidad.TipoLocalidad,
                CantRecolectada = localidad.CantRecolectada,
                TipoSurtido = localidad.TipoSurtido,
                Finalizar = localidad.Finalizar,
                Detalle = localidad.Detalle,
                IdArea = localidad.IdArea
            },
            Detalles = detalles.Select(d => new DetallePedidoDto
            {
                NumPedido = d.NumPedido,
                Clave = d.Clave,
                Descripcion = d.Descripcion,
                Cantidad = d.Cantidad,
                Unidad = d.Unidad,
                Comentarios = d.Comentarios,
                ConteoVerificacionStock = d.ConteoVerificacionStock
            }).ToList()
        };
    }
}
