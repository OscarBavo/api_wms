namespace ApiWms.Application.DTOs.Surtido;

public class ValidarTransitoLocalidadWmsResponseDto
{
    public int Code { get; set; }
    public string Response { get; set; } = string.Empty;
    public int Status { get; set; }
    public TransitoLocalidadDatosDto? Datos { get; set; }
}

public class TransitoLocalidadDatosDto
{
    public string Resultado { get; set; } = string.Empty;
    public string Mensaje { get; set; } = string.Empty;
}
