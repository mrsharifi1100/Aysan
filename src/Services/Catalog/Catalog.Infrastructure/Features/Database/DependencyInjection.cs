using Catalog.Infrastructure.Features.Database.Dapper.Catalog;

namespace Catalog.Infrastructure.Features.Database;

public static class DependencyInjection
{
    public static IServiceCollection AddDatabaseInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<CatalogContext>(options =>
            options.UseSqlServer(
                configuration["Catalog:DefaultConnection"],
                sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 10,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                })
        );

        services.Configure<CatalogOptions>(configuration.GetSection("Catalog"));

        services.AddScoped<ICatalogItemReadRepository, CatalogItemReadRepository>();
        services.AddScoped<ICatalogTypeReadRepository, CatalogTypeReadRepository>();

        services.AddScoped<ICatalogTypeRepository,CatalogTypeRepository>();
        services.AddScoped<ICatalogItemRepository, CatalogItemRepository>();

        return services;
    }
}