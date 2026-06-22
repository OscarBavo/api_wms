using System.ComponentModel.DataAnnotations;

namespace ApiWms.Application.DTOs;

public class LoginRequestDto
{
    [Required]
    public string Usuario { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    [Required]
    public string MacAddress { get; set; } = string.Empty;

    [Required]
    public string NumeroSerie { get; set; } = string.Empty;

    [Required]
    public string ModeloTerminal { get; set; } = string.Empty;

    [Required]
    public string VersionWms { get; set; } = string.Empty;
    [Required]
    public string compilacion { get; set; } = string.Empty;
}
