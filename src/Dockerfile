#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Orders.Api/Orders.Api.csproj", "Orders.Api/"]
COPY ["Orders.Domain/Orders.Domain.csproj", "Orders.Domain/"]
COPY ["Orders.AppService/Orders.AppService.csproj", "Orders.AppService/"]
COPY ["Orders.Respository/Orders.Respository.csproj", "Orders.Respository/"]
COPY ["Orders.Data/Orders.Data.csproj", "Orders.Data/"]
RUN dotnet restore "Orders.Api/Orders.Api.csproj"
COPY . .
WORKDIR "/src/Orders.Api"
RUN dotnet build "Orders.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Orders.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Orders.Api.dll"]

