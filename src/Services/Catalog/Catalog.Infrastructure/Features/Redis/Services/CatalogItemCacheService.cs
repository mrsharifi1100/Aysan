using Catalog.Infrastructure.Features.Redis.Common;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Catalog.Infrastructure.Features.Redis.Services
{
    public class CatalogItemCacheService:ICatalogItemCacheService
    {
        private readonly ICatalogItemReadRepository _catalogItemReadRepository;
        private readonly IRedisCacheService _redisCache;
        private readonly ILogger<CatalogItemCacheService> _logger;

        public CatalogItemCacheService(
            ICatalogItemReadRepository catalogItemReadRepository,
            IRedisCacheService redisCache,
            ILogger<CatalogItemCacheService> logger)
        {
            _catalogItemReadRepository = catalogItemReadRepository;
            _redisCache = redisCache;
            _logger = logger;
        }

        public async Task InitializeCatalogCacheAsync(
            CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Starting Catalog Redis cache initialization.");

            var catalogItems = await _catalogItemReadRepository
                .GetAllCatalogItems();

            foreach (var item in catalogItems.Data)
            {
                var key = $"catalog:{item.Id}";

                var entries = new HashEntry[]
                {
                    new("id", item.Id),
                    new("name", item.Name),
                    new("price", item.Price.ToString(
                        CultureInfo.InvariantCulture)),
                    new("description", item.Description ?? string.Empty),
                    new("isDiscount", item.IsDiscount.ToString()),
                    new("availableStock", item.AvailableStock)
                };

                await _redisCache.SetHashAsync(key, entries);

                _logger.LogDebug(
                    "Catalog item {CatalogItemId} cached in Redis.",
                    item.Id);
            }
        }

    }
}
