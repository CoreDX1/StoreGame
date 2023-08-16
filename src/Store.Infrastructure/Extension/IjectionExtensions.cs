using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Infrastructure.Persistences.Repository;
using Store.Infrastructure.Persistences.Interfaces;

namespace Store.Infrastructure.Extension;

public static class IjectionExtensions
{
    public static IServiceCollection AddInjectionInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var assembly = typeof(StoregameContext).Assembly.FullName;
        services.AddDbContext<StoregameContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("StringConnection"),
                b => b.MigrationsAssembly(assembly)
            );
        });
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IGameRepository, GameRepository>();
        return services;
    }
}
