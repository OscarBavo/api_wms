namespace ApiWms.Application.DTOs.Surtido;

public class FinalizarTransitoLocalidadResponseDto
{
    public int Code { get; set; }
    public string Response { get; set; } = string.Empty;
    public int Status { get; set; }
    public FinalizarTransitoLocalidadDatosDto? Datos { get; set; }
}

public class FinalizarTransitoLocalidadDatosDto
{
    public int IdLocalidad { get; set; }
    public string CodigoLocalidad { get; set; } = string.Empty;
    public decimal Cantidad { get; set; }
    public string Unidad { get; set; } = string.Empty;
}
