#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/services/Inventory/Inventory.Api/Inventory.Api.csproj", "src/services/Inventory/Inventory.Api/"]
COPY ["src/services/Inventory/Inventory.Domain/Inventory.Domain.csproj", "src/services/Inventory/Inventory.Domain/"]
COPY ["src/shared/SharedProject/SharedProject.csproj", "src/shared/SharedProject/"]
COPY ["src/services/Inventory/Inventory.Infrastructure/Inventory.Infrastructure.csproj", "src/services/Inventory/Inventory.Infrastructure/"]
RUN dotnet restore "./src/services/Inventory/Inventory.Api/./Inventory.Api.csproj"
COPY . .
WORKDIR "/src/src/services/Inventory/Inventory.Api"
RUN dotnet build "./Inventory.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Inventory.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Inventory.Api.dll"]