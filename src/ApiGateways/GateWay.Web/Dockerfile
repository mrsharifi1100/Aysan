FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base

WORKDIR /app

EXPOSE 8080
EXPOSE 8081


FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY ["src/ApiGateways/GateWay.Web/GateWay.Web.csproj", "src/ApiGateways/GateWay.Web/"]

RUN dotnet restore "src/ApiGateways/GateWay.Web/GateWay.Web.csproj"

COPY . .

WORKDIR "/src/src/ApiGateways/GateWay.Web"

RUN dotnet publish "GateWay.Web.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false


FROM base AS final

WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "GateWay.Web.dll"]