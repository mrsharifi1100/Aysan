

namespace Catalog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationAssembly(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        services.AddValidatorsFromAssembly(typeof(ApplicationAssemblyMarker).Assembly);

        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));

        return services;
    }
}