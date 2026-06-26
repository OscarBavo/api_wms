namespace ApiWms.Application.DTOs.Surtido;

public class ValidarUbicacionTransitoWmsResponseDto
{
    public int Code { get; set; }
    public string Response { get; set; } = string.Empty;
    public int Status { get; set; }
    public RespuestaIntercambioDto? RespuestaIntercambio { get; set; }
}

public class RespuestaIntercambioDto
{
    public string Resultado { get; set; } = string.Empty;
    public string Mensaje { get; set; } = string.Empty;
}
