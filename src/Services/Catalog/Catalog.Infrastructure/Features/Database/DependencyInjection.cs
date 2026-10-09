namespace Catalog.Infrastructure.Features.Database;

public static class DependencyInjection
{
    public static IServiceCollection AddDatabaseInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<CatalogContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
            })
        );
        return services;
    }
}