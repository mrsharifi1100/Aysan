
namespace Discount.Api
{
    public static class DependencyInejction
    {
        public static IServiceCollection AddDiscountServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddControllers();
            
            services.AddScoped<CatalogGrpcClientService>();
            services.AddSingleton<ClientLoggingInterceptor>();

            services.AddGrpcClient<CatalogGrpc.CatalogGrpcClient>(
                options =>
                {
                    options.Address = new Uri(
                        configuration["CatalogGrpcUrl"]!);
                }).AddInterceptor<ClientLoggingInterceptor>();
            return services;
        }
    }
}
