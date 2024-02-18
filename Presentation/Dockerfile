#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["Presentation.Customer/Presentation.Customer.csproj", "Presentation.Customer/"]
COPY ["Business/Business.csproj", "Business/"]
COPY ["Business.Abstractions/Business.Abstractions.csproj", "Business.Abstractions/"]
COPY ["Entities/Entities.csproj", "Entities/"]
COPY ["Infra.Dependency/Infra.Dependency.csproj", "Infra.Dependency/"]
COPY ["Infra.Ioc/Infra.Ioc.csproj", "Infra.Ioc/"]
COPY ["Infra.Storage/Infra.Storage.csproj", "Infra.Storage/"]
RUN dotnet restore "Presentation.Customer/Presentation.Customer.csproj"
COPY . .
WORKDIR "/src/Presentation.Customer"
RUN dotnet build "Presentation.Customer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Presentation.Customer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Presentation.Customer.dll"]