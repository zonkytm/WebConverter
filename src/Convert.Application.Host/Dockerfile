#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Convert.Application.AppServices/Convert.Application.AppServices.csproj", "src/Convert.Application.AppServices/"]
COPY ["src/Convert.Application.AppServices.Contracts/Convert.Application.AppServices.Contracts.csproj", "src/Convert.Application.AppServices.Contracts/"]
COPY ["src/Convert.Application.Api.Contracts/Convert.Application.Api.Contracts.csproj", "src/Convert.Application.Api.Contracts/"]
COPY ["src/Convert.Application.Host/Convert.Application.Host.csproj", "src/Convert.Application.Host/"]
RUN dotnet restore "src/Convert.Application.Host/Convert.Application.Host.csproj"
COPY . .
WORKDIR "/src/src/Convert.Application.Host"
RUN dotnet build "Convert.Application.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Convert.Application.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Convert.Application.Host.dll"]