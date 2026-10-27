namespace Common.ErrorHandler;

public static class ExceptionHandlingExtensions
{
    public static IServiceCollection AddCommonErrorHandling(
        this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        return services;
    }

    public static WebApplication UseCommonErrorHandling(
        this WebApplication app)
    {
        app.UseExceptionHandler();

        return app;
    }
}