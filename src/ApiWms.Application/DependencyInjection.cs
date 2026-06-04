using ApiWms.Application.Interfaces;
using ApiWms.Application.Interfaces.Surtido;
using ApiWms.Application.Services;
using ApiWms.Application.Services.Surtido;
using Microsoft.Extensions.DependencyInjection;

namespace ApiWms.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ISurtidoService, SurtidoService>();
        return services;
    }
}
