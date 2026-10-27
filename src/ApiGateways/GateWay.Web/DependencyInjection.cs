namespace GateWay.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection GateWayInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddIdentityInfrastructure(configuration);
            return services;
        }
    }
}
