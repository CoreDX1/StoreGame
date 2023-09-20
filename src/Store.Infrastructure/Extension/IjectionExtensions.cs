using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Entities;
using Store.Infrastructure.Persistences.Context;
using Store.Infrastructure.Persistences.Interfaces;
using Store.Infrastructure.Persistences.Repository;

namespace Store.Infrastructure.Extension;

public static class IjectionExtensions
{
    public static IServiceCollection AddInjectionInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var assembly = typeof(StoregameContext).Assembly.FullName;

        // Initialising my DbContext
        services.AddDbContext<StoregameContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("StringConnection"),
                b => b.MigrationsAssembly(assembly)
            );
        });
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IGameRepository, GameRepository>();
        services.AddScoped(typeof(IGenericRespository<>), typeof(GenericRepository<>));
        return services;
    }
}
