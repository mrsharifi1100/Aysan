var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices();
builder.Services.AddControllers();
builder.Host.AddLoggingServices();
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

#region Serilog


#endregion

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
