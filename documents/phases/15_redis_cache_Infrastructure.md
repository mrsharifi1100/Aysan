## Phase 15 — Redis Cache Infrastructure

## Goal

Set up Redis for the Catalog service and establish the initial caching infrastructure, including Redis connectivity, cache service abstractions, catalog item caching, automatic cache initialization, and Dependency Injection configuration.

## Tip

You Need These Packages:

* `StackExchange.Redis`
* `Microsoft.Extensions.Options.ConfigurationExtensions`

## 1 - Add Redis and RedisInsight to Docker Compose

Add Redis and RedisInsight containers to `<span>docker-compose.yml</span>`.

Configure port mappings, persistent storage for Redis, and the required container dependencies.

Ensure that RedisInsight can connect to Redis through the Docker Compose network.

## 2 - Configure Redis Connection

Add the Redis configuration to the application configuration in:

`appsettings.Development.json`

Configure the following settings:

* `ConnectionString`
* `InstanceName`

Configure the Redis connection string for both local development and Docker environments.

## 3 - Create IRedisCacheService

Create the `IRedisCacheService` interface and its implementation in the Infrastructure layer.

Define the common Redis cache operations, such as storing, retrieving, and removing cached data.

Implement these operations using `StackExchange.Redis` and keep the low-level Redis access behind this abstraction.

## 4 - Create ICatalogItemCacheService

Create the `ICatalogItemCacheService` interface in the Application layer.

Define the catalog-specific caching operations required by the application.

Implement `CatalogItemCacheService` in the Infrastructure layer and use `IRedisCacheService` to perform the underlying Redis operations.

## 5 - Create RedisCacheInitializer

Create the `RedisCacheInitializer` class in the Infrastructure layer.

Implement `IHostedService` to initialize the catalog item cache automatically when the application starts.

Use `IServiceScopeFactory` to resolve the required cache service within a dependency injection scope.

## 6 - Configure Redis Dependency Injection

Create or update the Redis `DependencyInjection.cs` file in the Infrastructure layer.

Configure the Redis connection using the application settings and register the required Redis services.

Register `IRedisCacheService`, `CatalogItemCacheService`, and `RedisCacheInitializer` with the appropriate service lifetimes.

Register the hosted service using:

`services.AddHostedService<RedisCacheInitializer>();`

## 7 - Register Redis in the Main Infrastructure Dependency Injection

Update the main Infrastructure `DependencyInjection.cs` file.

Call the Redis-specific dependency registration method to register the Redis configuration and services through the main Infrastructure composition root.

Ensure that `Catalog.Api` can access the registered Redis services through the existing Infrastructure dependency injection setup.

## Result

Redis and RedisInsight are configured through Docker Compose, and the Catalog service has the initial caching infrastructure required to store and retrieve catalog items from Redis.

The catalog cache is initialized automatically when the application starts, and Redis dependencies are registered through the Infrastructure Dependency Injection setup.

## Related Files

[Redis Dependency Injection]()
