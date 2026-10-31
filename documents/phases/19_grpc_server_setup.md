## Phase 16 — gRPC Server Setup

## Goal

Set up gRPC in the Catalog service, define the communication contract using Protocol Buffers, configure Kestrel for HTTP/2, implement the gRPC service, and expose the service endpoints.

## Tip

You Need These Packages:

* `Google.Protobuf`
* `Grpc.AspNetCore`
* `Grpc.Tools`
* `Grpc.Net.Client`

## 1 - Install gRPC Packages

Install the required gRPC packages in the `<span>Catalog.Api</span>` project.

Use `<span>Grpc.AspNetCore</span>` to host gRPC services, `<span>Google.Protobuf</span>` to work with Protocol Buffers, and `<span>Grpc.Tools</span>` to generate C# code from `<span>.proto</span>` files.

## 2 - Create Proto and gRPC Service Folders

Create the following folders in the `<span>Catalog.Api</span>` project:

* `Proto` — stores the `.proto` contract files.
* `Grpc/Services` — stores the gRPC service implementations.

Keep the communication contracts separate from the service implementation classes.

## 3 - Configure Proto File Generation

Update `Catalog.Api.csproj` to include the Proto file and generate server-side gRPC code.

Configure the following item:

`<Protobuf Include="Proto\catalog.proto" GrpcServices="Server" />`

Use `GrpcServices="Server"` to generate the server-side code required by the Catalog service.

## 4 - Set P

## 4 - Configure Kestrel for gRPC

Configure Kestrel in `Program.cs` to support HTTP/2 for incoming gRPC requests.

Use a dedicated HTTP/2 endpoint for gRPC when required by the application configuration.

If REST APIs and Swagger also need to run over HTTPS, configure their endpoint separately and ensure that the ports, protocols, and HTTPS certificates are consistent with the development environment.

## 5 - Define the Catalog Proto Contract

Create `Proto/catalog.proto` and define the Catalog gRPC service contract.

Define the RPC methods, request messages, and response messages required by the Catalog service.

For example, define `GetAllCatalogItems` and its corresponding request and response messages.

Use the Proto contract to specify the communication structure between the gRPC client and server.

## 6 - Register gRPC Services

Update the API Dependency Injection configuration and register gRPC using:

`services.AddGrpc();`

Enable detailed errors only in development environments when necessary.

## 7 - Implement CatalogGrpcService

Create `CatalogGrpcService` in `Grpc/Services`.

Inherit from the generated `CatalogGrpc.CatalogGrpcBase` class and implement the RPC methods defined in `catalog.proto`.

Use the existing Application layer, such as MediatR queries, to retrieve catalog data and map the results to the generated Protobuf response messages.

## 8 - Map the gRPC Service Endpoint

Update `Program.cs` and map the gRPC service using:

`app.MapGrpcService<CatalogGrpcService>();`

This registers the gRPC service endpoints with ASP.NET Core routing so that clients can invoke the defined RPC methods.

## 9 - Expose the Proto File for Inspection

Optionally, add an HTTP endpoint to expose the contents of `catalog.proto`.

Use a route such as `/_proto/` to return the Proto file as plain text.

This endpoint is intended for inspecting or retrieving the contract and is not required for gRPC communication itself.

## Result

The Catalog service hosts a gRPC server over HTTP/2, exposes the RPC methods defined in `catalog.proto`, and uses the Application layer to retrieve and return catalog data through Protobuf response messages.

The Proto contract can optionally be inspected through an HTTP endpoint, and the service is ready for integration with gRPC clients.

## Related Files

* `<span>Catalog.Api.csproj</span>`
