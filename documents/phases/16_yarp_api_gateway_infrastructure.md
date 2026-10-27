# Phase 16 — YARP API Gateway

## Goal

Create a dedicated API Gateway using YARP (Yet Another Reverse Proxy) to route incoming HTTP requests to the Catalog API. Configure the Gateway using `<span>appsettings.Development.json</span>`, containerize the application with Docker, and configure Docker Compose to run both the Gateway and Catalog API together.

## Tip

Remember:

* `Yarp.ReverseProxy` package

## 1 - Create Gateway Project

Create a new ASP.NET Core project named `GateWay.Web` under `src/ApiGateways`.

* Use the `dotnet new web` template.
* Keep the Gateway as a separate application from `Catalog.API`.
* Do not add Controllers unless custom Gateway endpoints are required.

## 2 - Configure Docker

* Create a multi-stage Dockerfile for the Gateway using the .NET 10 SDK and ASP.NET runtime images.
* Configure `docker-compose.yml` to build and run the Gateway alongside Catalog API.
* Set the appropriate port mappings and use the Catalog service name and internal port for communication between containers.
* Ensure the Gateway uses the correct configuration for local development and Docker environments.

## 3 - Configure Program.cs

Configure YARP in `Program.cs`.

* Register the Reverse Proxy services using `AddReverseProxy()`.
* Map the proxy endpoints using `app.MapReverseProxy()`.
* Keep the application minimal and avoid unnecessary Controller registration.
* Configure HTTPS redirection only when appropriate for the Gateway's hosting setup.

## 4 - Configure appsettings.Development.json

Configure the `ReverseProxy` section in `appsettings.Development.json`.

* Define a route for incoming Catalog API requests.
* Configure the route to match `/catalog-api/{**remainder}`.
* Associate the route with `catalog-cluster`.
* Ensure the forwarded request path matches the actual Catalog API endpoint.

## 5 - Configure Startup and Launch Settings

Configure the development launch settings so both `GateWay.Web` and `Catalog.API` can run together.

* Set the appropriate HTTP and HTTPS URLs for local development.
* Configure both projects to start simultaneously in Visual Studio.
* Verify that the Gateway can reach the Catalog API using its configured destination.
* Keep host-based URLs separate from Docker service addresses.

## Result

The `<span>GateWay.Web</span>` application acts as a dedicated YARP API Gateway for the Catalog API. Incoming requests are routed to Catalog through centralized Reverse Proxy configuration. Both applications can run together during development and communicate through Docker Compose when containerized.
