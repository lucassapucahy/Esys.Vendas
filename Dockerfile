#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Esys.Vendas.Api/Esys.Vendas.Api.csproj", "Esys.Vendas.Api/"]
COPY ["Esys.Vendas.Domain/Esys.Vendas.Domain.csproj", "Esys.Vendas.Domain/"]
COPY ["Esys.Vendas.Infra/Esys.Vendas.Infra.csproj", "Esys.Vendas.Infra/"]
RUN dotnet restore "Esys.Vendas.Api/Esys.Vendas.Api.csproj"
COPY . .
WORKDIR "/src/Esys.Vendas.Api"
RUN dotnet build "Esys.Vendas.Api.csproj" -c Release -o /app/build

ENV ASPNETCORE_ENVIRONMENT="Development"

FROM build AS publish
RUN dotnet publish "Esys.Vendas.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Esys.Vendas.Api.dll"]