namespace Catalog.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        #region Swagger Service
        services.AddSwaggerGen();
        #endregion

        return services;
    }
}

