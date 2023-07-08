#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Eventhub.API/Eventhub.API.csproj", "Eventhub.API/"]
COPY ["Eventhub.CrossCutting/Eventhub.CrossCutting.csproj", "Eventhub.CrossCutting/"]
COPY ["Eventhub.Domain/Eventhub.Domain.csproj", "Eventhub.Domain/"]
RUN dotnet restore "Eventhub.API/Eventhub.API.csproj"
COPY . .
WORKDIR "/src/Eventhub.API"
RUN dotnet build "Eventhub.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Eventhub.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Eventhub.API.dll"]