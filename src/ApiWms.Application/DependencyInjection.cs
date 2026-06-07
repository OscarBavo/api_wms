using ApiWms.Application.Interfaces;
using ApiWms.Application.Interfaces.Configuracion;
using ApiWms.Application.Interfaces.Surtido;
using ApiWms.Application.Services;
using ApiWms.Application.Services.Configuracion;
using ApiWms.Application.Services.Surtido;
using Microsoft.Extensions.DependencyInjection;

namespace ApiWms.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ISurtidoService, SurtidoService>();
        services.AddScoped<IConfiguracionService, ConfiguracionService>();
        return services;
    }
}
