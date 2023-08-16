using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.Interface;
using Store.Application.Services;

namespace Store.Application.Extension;

public static class InjectionExtensions
{
    public static IServiceCollection AddInjectionApplication(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddSingleton(configuration);
        services.AddScoped<IGameApplication, GameApplication>();
        return services;
    }
}
