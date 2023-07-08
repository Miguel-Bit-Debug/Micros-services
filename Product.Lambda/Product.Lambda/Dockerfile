#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_ENVIRONMENT=Development


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Product.Lambda/Product.Lambda.csproj", "Product.Lambda/"]
COPY ["Product.Domain/Product.Domain.csproj", "Product.Domain/"]
COPY ["Product.InfraData/Product.InfraData.csproj", "Product.InfraData/"]
RUN dotnet restore "Product.Lambda/Product.Lambda.csproj"
COPY . .
WORKDIR "/src/Product.Lambda"
RUN dotnet build "Product.Lambda.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Product.Lambda.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Product.Lambda.dll"]