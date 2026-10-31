namespace Catalog.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddInfrastructureAssembly(configuration);
        services.AddApplicationAssembly();
        services.AddCommonErrorHandling();

        services.AddControllers();
        // Swagger Services
        #region Swagger Service
        services.AddSwaggerGen();
        #endregion

        //Api Versioning
        #region Api Versioning
        services
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        #endregion

        #region Cors Policy

        services.AddCors(options =>
        {
            options.AddPolicy("NextJs", policy =>
            {
                policy
                    .WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        #endregion

        #region Health Check

        services.AddHealthChecks();

        #endregion

        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddSingleton<IExceptionToProblemDetailsMapper,CatalogExceptionMapper>();

        services.AddGrpc(option =>
        {
            option.EnableDetailedErrors = true;
        });
        return services;
    }
}