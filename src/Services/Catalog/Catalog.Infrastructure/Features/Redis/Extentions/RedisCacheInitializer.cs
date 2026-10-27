using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Features.Redis.Extentions
{
    public sealed class RedisCacheInitializer(
    IServiceScopeFactory scopeFactory) : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await using var scope = scopeFactory.CreateAsyncScope();

            var cache = scope.ServiceProvider
                .GetRequiredService<ICatalogItemCacheService>();

            await cache.InitializeCatalogCacheAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
