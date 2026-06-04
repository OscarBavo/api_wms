using ApiWms.Application.Interfaces;
using ApiWms.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApiWms.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}
