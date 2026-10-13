var builder = WebApplication.CreateBuilder(args);

builder.Host.AddLoggingServices();

builder.Services.AddApiServices(builder.Configuration);
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

app.UseHttpsRedirection();

app.MapControllers();

app.MapHealthChecks("/health");

app.UseCommonErrorHandling();

app.Run();
