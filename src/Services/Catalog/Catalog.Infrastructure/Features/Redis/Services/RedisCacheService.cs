using Catalog.Infrastructure.Features.Redis.Common;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Catalog.Infrastructure.Features.Redis.Services;
public sealed class RedisCacheService : IRedisCacheService
{
    private readonly IConnectionMultiplexer _redis;
    private readonly StackExchange.Redis.IDatabase _database;

    public RedisCacheService(IConnectionMultiplexer redis)
    {
        _redis = redis;
        _database = _redis.GetDatabase();
    }

    public async Task SetHashAsync(
string key,
HashEntry[] entries,
TimeSpan? expiration = null)
    {
        await _database.HashSetAsync(
            key,
            entries);

        if (expiration.HasValue)
        {
            await _database.KeyExpireAsync(
                key,
                expiration.Value);
        }
    }

    public async Task<T?> GetHashAsync<T>(
        string key,
        string field)
    {
        var value = await _database.HashGetAsync(
            key,
            field);

        if (value.IsNullOrEmpty)
            return default;

        return JsonSerializer.Deserialize<T>(
            value.ToString());
    }

    public async Task RemoveAsync(string key)
    {
        await _database.KeyDeleteAsync(key);
    }

    public async Task<bool> HashExistsAsync(
        string key,
        string field)
    {
        return await _database.HashExistsAsync(
            key,
            field);
    }
}