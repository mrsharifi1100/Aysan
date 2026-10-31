# Phase 20 — gRPC Client Integration in Discount Service

## Goal

Configure `<span>Discount.Api</span>` as a gRPC client to communicate with `<span>Catalog.Api</span>`. Register the generated gRPC client in Dependency Injection, configure the Catalog gRPC endpoint, implement a dedicated client class, and consume Catalog data without creating an HTTP controller for the gRPC client.

## Tip

You Need These Packages:

* `Google.Protobuf`
* `Grpc.Net.Client`
* `Grpc.Tools`
* `Grpc.Net.ClientFactory`

## 1 - Add the Catalog Proto Contract

Create a `Proto` folder in `Discount.Api` and add the `catalog.proto` contract used by `Catalog.Api`.

The client must use a compatible contract containing the same service name, RPC method, request message, and response message definitions.

Configure the `.csproj` file to generate client code:

```
<ItemGroup>
  <Protobuf Include="Proto\catalog.proto" GrpcServices="Client" />
</ItemGroup>
```

## 2 - Configure the Catalog gRPC URL

Add the Catalog gRPC endpoint to `<span>appsettings.json</span>` or the appropriate environment-specific configuration file.

```
{
  "CatalogGrpcUrl": "http://localhost:8082"
}
```

Use the address appropriate to the current environment. When running inside Docker Compose, the client should use the Catalog service name and its internal gRPC port, for example:

`http://catalog-api:8082`

## 3 - Register the gRPC Client in Dependency Injection

Register the generated gRPC client in the `Discount.Api` Dependency Injection configuration.

* Use `AddGrpcClient<T>()`.
* Read the endpoint from configuration.
* Configure the client address using `CatalogGrpcUrl`.
* Add a client interceptor if logging or other cross-cutting client behavior is required.

## 4 - Implement a Dedicated Catalog gRPC Client

Create a dedicated client class in `Discount.Api` to encapsulate calls to the Catalog gRPC service.

* Inject the generated Catalog gRPC client.
* Call `GetAllCatalogItemsAsync()` to retrieve Catalog data.
* Map the gRPC response to the appropriate Discount application model when necessary.
* Keep gRPC communication logic separate from business logic.

Do not create an HTTP controller just to consume the gRPC service. The generated gRPC client can be injected directly into an application service or another appropriate component through Dependency Injection.

## 5 - Configure the Discount Service to Consume Catalog Data

Use the dedicated Catalog gRPC client from the appropriate Discount application component.

* Call the client asynchronously.
* Pass a cancellation token where appropriate.
* Handle communication failures and deadlines appropriately.
* Avoid coupling the Discount domain model directly to generated Protobuf classes.

## 6 - Test the gRPC Communication

Run `<span>Catalog.Api</span>` and `<span>Discount.Api</span>`, then verify that Discount can successfully call the Catalog gRPC service.

* Confirm that the Catalog gRPC endpoint is reachable.
* Verify that `<span>GetAllCatalogItemsAsync()</span>` returns the expected data.
* Check that the generated client contract matches the Catalog server contract.
* Test the behavior when Catalog is unavailable or returns an error.
* Check application logs for connection or serialization issues.

Complete this phase only after the gRPC communication has been tested successfully.

## 7 - Configure Dockerfile and Docker Compose for Discount.Api

Create or update the `<span>Discount.Api</span>` Dockerfile and configure its service in `docker-compose.yml`.

Remember that `localhost` inside the Discount container refers to the Discount container itself, not the Catalog container. Use `catalog-api` as the hostname for container-to-container communication.

## Result

At the end of this phase, `Discount.Api` will have a configured gRPC client that can consume Catalog data through a dedicated client class. The communication will first be tested locally and then verified in the Docker Compose environment.
