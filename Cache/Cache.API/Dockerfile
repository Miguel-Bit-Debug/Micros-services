#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Cache.API/Cache.API.csproj", "Cache.API/"]
COPY ["Cache.CrossCutting/Cache.CrossCutting.csproj", "Cache.CrossCutting/"]
COPY ["Cache.Domain/Cache.Domain.csproj", "Cache.Domain/"]
COPY ["Cache.InfraData/Cache.InfraData.csproj", "Cache.InfraData/"]
RUN dotnet restore "Cache.API/Cache.API.csproj"
COPY . .
WORKDIR "/src/Cache.API"
RUN dotnet build "Cache.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cache.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cache.API.dll"]