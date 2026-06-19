using System.Text.Json.Serialization;

namespace ApiWms.Application.DTOs;

public class AgregarSesionResponseDto
{
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("response")]
    public string Response { get; set; } = string.Empty;

    [JsonPropertyName("status")]
    public int Status { get; set; }
}
