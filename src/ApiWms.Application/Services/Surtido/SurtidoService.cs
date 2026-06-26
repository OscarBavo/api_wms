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
                CodigoLocalidad = d.CodigoLocalidad,
                Unidad = d.Unidad,
                Comentarios = d.Comentarios,
                ConteoVerificacionStock = d.ConteoVerificacionStock
            }).ToList()
        };
    }

    public async Task<ValidarArticuloResponseDto> ValidarArticuloAsync(ValidarArticuloRequestDto request)
    {
        if (request.pIdRecoleccion is null || request.pIdOrdenEmbarque is null ||
            request.pIdLocalidad is null || request.pIdUsuario is null)
        {
            return new ValidarArticuloResponseDto { Code = -1, Response = "no info", Status = 0 };
        }

        try
        {
            var articulos = await _surtidoRepository.ValidarArticuloAsync(
                request.pIdRecoleccion.Value,
                request.pIdOrdenEmbarque.Value,
                request.pIdLocalidad.Value,
                request.pIdUsuario.Value,
                request.pCodigoUbicacionesSurtidas);

            return new ValidarArticuloResponseDto
            {
                Code = 1,
                Response = "OK",
                Status = 200,
                RecoleccionDatos = articulos.Select(a => new ArticuloRecoleccionDto
                {
                    IdRecoleccion = a.IdRecoleccion,
                    IdOrdenEmbarque = a.IdOrdenEmbarque,
                    NumPedido = a.NumPedido,
                    IdLocalidad = a.IdLocalidad,
                    IdEstilo = a.IdEstilo,
                    Articulo = a.Articulo,
                    Descripcion = a.Descripcion,
                    MultiploCaja = a.MultiploCaja,
                    LeyendaSurtido = a.LeyendaSurtido,
                    SinCodigoBarras = a.SinCodigoBarras,
                    Lote = a.Lote,
                    CantPresentacion = a.CantPresentacion,
                    NombrePresentacion = a.NombrePresentacion,
                    CantidadSurtir = a.CantidadSurtir
                }).ToList()
            };
        }
        catch(Exception ex)
        {
            return new ValidarArticuloResponseDto { Code = -1, Response = ex.Message, Status = 400 };
        }
    }

    public async Task<ValidarArticuloSkuResponseDto> ValidarArticuloSkuAsync(ValidarArticuloSkuRequestDto request)
    {
        if (request.pIdRecoleccion is null || request.pIdLocalidad is null ||
            request.pIdUsuario is null || request.pIdOrdenEmbarque is null ||
            string.IsNullOrWhiteSpace(request.pCodigoSku))
        {
            return new ValidarArticuloSkuResponseDto { Code = -1, Response = "no info", Status = 0 };
        }

        try
        {
            var articulos = await _surtidoRepository.ValidarArticuloSkuAsync(
                request.pIdRecoleccion.Value,
                request.pIdLocalidad.Value,
                request.pCodigoSku,
                request.pIdUsuario.Value,
                request.pCodigoUbicacionesSurtidas,
                request.pIdOrdenEmbarque.Value);

            if (articulos[0].Descripcion == "SkuNoExiste") { 
                return new ValidarArticuloSkuResponseDto
                    {
                        Code = -1,
                        Response = "El SKU no existe en la localidad.",
                        Status = 400
                    };
            }

            return new ValidarArticuloSkuResponseDto
            {
                Code = 1,
                Response = "OK",
                Status = 200,
                RecoleccionArticuloDatos = articulos.Select(a => new ArticuloSkuDto
                {
                    ClaveArticulo = a.ClaveArticulo,
                    Descripcion = a.Descripcion,
                    Cantidad = a.Cantidad,
                    Unidad = a.Unidad,
                    MultiploCaja = a.MultiploCaja,
                    IdOrdenEmbarque = a.IdOrdenEmbarque,
                    NumPedido = a.NumPedido,
                    IdLocalidadTransito = a.IdLocalidadTransito,
                    CodigoLocalidadTransito = a.CodigoLocalidadTransito,
                    LeyendaSurtido = a.LeyendaSurtido,
                    SinCodigoBarras = a.SinCodigoBarras,
                    ForzarLeyendaSurtido = a.ForzarLeyendaSurtido,
                    ValorAgregado = a.ValorAgregado,
                    ManejoLote = a.ManejoLote,
                    ManejoSerie = a.ManejoSerie,
                    Lote = a.Lote,
                    Presentacion = a.Presentacion,
                    MultPresentacion = a.MultPresentacion,
                    Sugerencia = a.Sugerencia,
                    Consolidacion = a.Consolidacion
                }).ToList()
            };
        }
        catch(Exception ex)
        {
            return new ValidarArticuloSkuResponseDto { Code = -1, Response = ex.Message, Status = 400 };
        }
    }

    public async Task<ValidarUbicacionTransitoWmsResponseDto> ValidarUbicacionTransitoWmsAsync(ValidarUbicacionTransitoWmsRequestDto request)
    {
        if (string.IsNullOrWhiteSpace(request.pClaveLocalidad) ||
            request.pIdUsuario is null ||
            string.IsNullOrWhiteSpace(request.pIdRecoleccionDetalle) ||
            string.IsNullOrWhiteSpace(request.pModuloWMS) ||
            request.pIdTipoUbicacion is null ||
            request.pIdIntercambio is null)
        {
            return new ValidarUbicacionTransitoWmsResponseDto { Code = -1, Response = "no info", Status = 0 };
        }

        try
        {
            var resultado = await _surtidoRepository.ValidarUbicacionTransitoWmsAsync(
                request.pClaveLocalidad,
                request.pIdUsuario.Value,
                request.pIdRecoleccionDetalle,
                request.pModuloWMS,
                request.pIdTipoUbicacion.Value,
                request.pIdIntercambio.Value);

            if (resultado == null)
                return new ValidarUbicacionTransitoWmsResponseDto { Code = -1, Response = "no info", Status = 0 };

            if (string.IsNullOrWhiteSpace(resultado.Mensaje) &&
                resultado.Resultado == "ErrorTraspasoAgregarIntercambio")
            {
                return new ValidarUbicacionTransitoWmsResponseDto
                {
                    Code = -2,
                    Response = "Error en validación",
                    Status = 400
                };
            }

            return new ValidarUbicacionTransitoWmsResponseDto
            {
                Code = 1,
                Response = "OK",
                Status = 200,
                RespuestaIntercambio = new RespuestaIntercambioDto
                {
                    Resultado = resultado.Resultado,
                    Mensaje = resultado.Mensaje
                }
            };
        }
        catch
        {
            return new ValidarUbicacionTransitoWmsResponseDto { Code = -1, Response = "Error SP", Status = 400 };
        }
    }
}
