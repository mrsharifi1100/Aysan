namespace GateWay.Web.Features.Keycloak
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIdentityInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme =
                        JwtBearerDefaults.AuthenticationScheme;

                    options.DefaultChallengeScheme =
                        JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.MetadataAddress =
                        configuration["Keycloak:Common:MetadataAddress"];

                    options.Authority =
                        configuration["Keycloak:Common:Authority"];

                    options.Audience =
                        configuration["Keycloak:Common:Audience"];

                    options.RequireHttpsMetadata =
                        configuration.GetValue<bool>(
                            "Keycloak:Common:RequireHttpsMetadata");

                    options.TokenValidationParameters =
                        new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateIssuerSigningKey = true,
                            ValidateLifetime = true,
                            RoleClaimType = ClaimTypes.Role,
                            ClockSkew = TimeSpan.FromMinutes(2)
                        };
                });

            return services;
        }

    }
}
