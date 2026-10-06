namespace Common.Logging;

public static class DependencyInjection
{
    public static IHostBuilder AddLoggingServices(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilog(
        (context, services, configuration) =>
        {
            configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext();
        });
        return hostBuilder;
    }
}

