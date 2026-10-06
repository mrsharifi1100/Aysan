## Docker

Docker is used to containerize the Aysan services and provide a consistent runtime environment across development and deployment environments.

## Docker Files

Each service uses a Dockerfile to define how its container image is built.

### Catalog Api

`src/Services/Catalog/Catalog.Api/Dockerfile`

## Docker Compose


Docker Compose is used to build and run the services and infrastructure components required by the Aysan system.

The Compose configurations is located at:

`docker-compose.yml`

`docker-compose.override.yml`

As new services and infrastructure components are added, they will be documented here.

## Build Stages

The Dockerfiles use a multi-stage build process:

* Base runtime image
* Build environment
* Application publish
* Final runtime image

## Configurations

### Environment Files

Current configuration files:

* #### Catalog.api

  * `.env`
  * `catalog.env`

Environment Variables

Important environment variables include:

* Application ports
* Database connection settings
* Redis configuration
* RabbitMQ configuration
* Service URLs
* Other environment-specific settings
* ,,,,,,,

Sensitive values should not be committed to the repository.

## Ports

Container and host port mappings are defined through Docker Compose.

Current ports:

* Catalog.Api
  * `CATALOG_HTTP_PORTS:5001`
  * `CATALOG_HTTPS_PORTS:5002`

## Build and Run

Build and start the complete environment:

```
docker compose up --build -d
```

Stop the containers:

```
docker compose down
```

View running containers:

```
docker compose ps
```

View logs:

```
docker compose logs
```

## Related Files

* [docker-compose.yml](../../../docker-compose.yml)
* [docker-compose.override.yml](../../../docker-compose.override.yml)
* [.dockerignore](../../../.dockerignore)
* [.env](../../../.env)
* [Catalog Dockerfile](../../../src/Services/Catalog/Catalog.Api/Dockerfile)
* [Catalog environment](../../../catalog.env)
