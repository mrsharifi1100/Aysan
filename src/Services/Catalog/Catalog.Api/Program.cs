using Catalog.Api.Grpc;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddLoggingServices();

builder.Services.AddApiServices(builder.Configuration);

builder.WebHost.ConfigureKestrel(options =>
{
    // HTTP/HTTPS endpoint for Swagger and REST
    options.ListenLocalhost(7182, listenOptions =>
    {
        listenOptions.UseHttps();
        listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
    });

    // HTTP/2 endpoint for gRPC
    options.ListenAnyIP(8082, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
    });
});
var app = builder.Build();

//Swagger Middleware
#region Swagger Middleware and add PATH_BASE
var pathBase = builder.Configuration["PATH_BASE"];

if (!string.IsNullOrEmpty(pathBase))
{
    app.UsePathBase(pathBase);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint(
            $"{(!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty)}/swagger/v1/swagger.json", "Catalog.Api V1");
    });
}
#endregion

app.UseCors("NextJs");

//app.UseHttpsRedirection();

app.MapControllers();

app.MapHealthChecks("/health");

app.UseCommonErrorHandling();

app.MapGet("/_proto/", async (IWebHostEnvironment env) =>
{
    var protoPath = Path.Combine(
        env.ContentRootPath,
        "Proto",
        "catalog.proto");

    return Results.Text(
        await File.ReadAllTextAsync(protoPath),
        "text/plain");
});

app.MapGrpcService<CatalogGrpcService>();

app.Run();
