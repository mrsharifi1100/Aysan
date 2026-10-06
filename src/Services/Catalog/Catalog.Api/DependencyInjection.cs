namespace Catalog.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        // Swagger Services
        #region Swagger Service
        services.AddSwaggerGen();
        #endregion

        return services;
    }
}

