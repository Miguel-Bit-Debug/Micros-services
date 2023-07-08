#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Messagehub.API/Messagehub.API.csproj", "Messagehub.API/"]
COPY ["Messagehub.CrossCutting/Messagehub.CrossCutting.csproj", "Messagehub.CrossCutting/"]
COPY ["Messagehub.Domain/Messagehub.Domain.csproj", "Messagehub.Domain/"]
COPY ["Messagehub.InfraData/Messagehub.InfraData.csproj", "Messagehub.InfraData/"]
RUN dotnet restore "Messagehub.API/Messagehub.API.csproj"
COPY . .
WORKDIR "/src/Messagehub.API"
RUN dotnet build "Messagehub.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Messagehub.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Messagehub.API.dll"]