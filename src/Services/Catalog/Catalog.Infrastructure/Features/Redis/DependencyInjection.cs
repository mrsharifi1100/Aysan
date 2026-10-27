using Catalog.Application.Common.Interfaces;
using Catalog.Infrastructure.Features.Redis.Common;
using Catalog.Infrastructure.Features.Redis.Extentions;
using Catalog.Infrastructure.Features.Redis.Options;
using Catalog.Infrastructure.Features.Redis.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Features.Redis
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRedisInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RedisOptions>(
                configuration.GetSection("Redis"));

            var connectionString =
            configuration["Redis:ConnectionString"];

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException(
                    "Redis connection string is not configured.");

            services.AddSingleton<IConnectionMultiplexer>(
                ConnectionMultiplexer.Connect(connectionString));

            services.AddSingleton<IRedisCacheService, RedisCacheService>();

            services.AddScoped<ICatalogItemCacheService, CatalogItemCacheService>();

            services.AddHostedService<RedisCacheInitializer>();

            return services;
        }
    }
}
