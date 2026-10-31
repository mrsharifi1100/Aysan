var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDiscountServices(builder.Configuration);
var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
