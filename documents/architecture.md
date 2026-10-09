# Aysan Architecture

Aysan is a microservices-based system built with ASP.NET Core.

The system is organized around independent business services. Each service is responsible for a specific business capability and can be developed, deployed, and scaled independently.

The system currently starts with the Catalog service and will gradually evolve by adding additional services and infrastructure components.

## High-Level Architecture

> The Gateway and additional services will be introduced in later phases. The current implementation starts with the Catalog service.

## Services

It is responsible for catalog-related operations and serves as the heart of the system, implemented using a pure DDD architecture.**Services are organized around business capabilities.

`src/Services/Catalog/Catalog.Api`

Additional Catalog components will be added as the service evolves.

## Gateway

The Gateway will be responsible for edge-level concerns such as:

* Request routing
* Authentication
* Rate limiting
* Observability

Business logic will remain inside the individual services.

## Service OwnerShip

Each service owns its business logic and data.

```text
Catalog
   |
   |___Catalog Database
```

Services should not directly access another service's database.

Communication between services will happen through defined APIs or messaging mechanisms.

## Communication

The system may use different communication mechanisms depending on the use case.

### Synchronous Communication

Used when an immediate response is required.

Client

↓

Gateway

↓

Service

↓

Response

### Asynchronous Communication

RabbitMQ will be used for asynchronous communication between services where appropriate.

Catalog

│

│ Event

▼

RabbitMQ

│

▼

Another Service

## Infrastructure

The system uses infrastructure components to support the services.

Planned infrastructure includes:

```
Aysan
|
|---Serilog
|---Swagger
|---Sql Server
```

## Containerization

```
Docker Compose
|
|---Catalog Api
```

## Project Structure

```

Aysan/
|
|___ src/
|   |___ Services/
|   |    |___ Catalog/
|   |        |___ Catalog.Api/
|   |        |      |___ Dockerfile
|   |        |      |___ Controllers/
|   |        |      |___ Logs/
|   |        |___ Catalog.Domain/
|   |        |    |___ AggregateModel/
|   |        |    |   |___ CatalogItemAggregate/
|   |        |    |   |___ CatalogTypeAggregate/
|   |        |    |___ Common/
|   |        |    |___ Exceptions/
|   |        |___ Catalog.Application/
|   |        |___ Catalog.Infrastructure/
|   |             |___ Features
|   |                 |___ Database
|   |                     |___ Configurations/
|   |                     |___ Context/
|   |                     |___ Migrations/
|   |
|   |  
|   |___ BuildingBlocks/
│         └── Logging/ 
│               └── Common.Logging/ 
|
|___ docs/
|
|___ .env
|___ catalog.env
|___ docker-compose.yml
|___ docker-compose.override.yml
|___ .dockerignore
|___ .gitignore
|___ Aysan.Sln

```

## Related Documentation

Detailed implementation and technology-specific documentation is available under:

[Technologies](./technologies)

The step-by-step development process is documented under:

[phases](./phases)
