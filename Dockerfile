#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Paqueteria.Api/Paqueteria.Api.csproj", "Paqueteria.Api/"]
RUN dotnet restore "Paqueteria.Api/Paqueteria.Api.csproj"
COPY . .
WORKDIR "/src/Paqueteria.Api"
RUN dotnet build "Paqueteria.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Paqueteria.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Paqueteria.Api.dll"]