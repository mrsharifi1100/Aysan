using GateWay.Web;
var builder = WebApplication.CreateBuilder(args);

//builder.Services.GateWayInfrastructure(builder.Configuration);
builder.Services
    .AddReverseProxy()
    .LoadFromConfig(
        builder.Configuration.GetSection("ReverseProxy"));
var app = builder.Build();

app.UseHttpsRedirection();

app.MapReverseProxy();

//app.UseAuthentication();
//app.UseAuthorization();

app.Run();
