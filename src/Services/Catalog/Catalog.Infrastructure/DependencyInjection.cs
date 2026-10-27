using Catalog.Infrastructure.Features.Redis;

namespace Catalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureAssembly(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDatabaseInfrastructure(configuration);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehaviour<,>));

        services.AddRedisInfrastructure(configuration);
        return services;
    }
}