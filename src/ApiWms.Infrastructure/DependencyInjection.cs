using ApiWms.Application.Interfaces;
using ApiWms.Application.Interfaces.Configuracion;
using ApiWms.Application.Interfaces.Surtido;
using ApiWms.Infrastructure.Persistence;
using ApiWms.Infrastructure.Repositories;
using ApiWms.Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;

namespace ApiWms.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<SqlConnectionFactory>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<ISurtidoRepository, SurtidoRepository>();
        services.AddScoped<IConfiguracionRepository, ConfiguracionRepository>();
        return services;
    }
}
