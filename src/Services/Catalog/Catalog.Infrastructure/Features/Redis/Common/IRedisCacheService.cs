using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Features.Redis.Common;
public interface IRedisCacheService
{
    Task SetHashAsync(
        string key,
        HashEntry[] entries,
        TimeSpan? expiration = null);

    Task<T?> GetHashAsync<T>(
        string key,
        string field);
    Task RemoveAsync(string key);
}
