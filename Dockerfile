# Dockerfile multi-stage pour SQL Server + API .NET

# Stage 1: Build de l'application .NET
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copier le fichier projet et restaurer les dépendances
COPY ServiceLigueHockeyV2/ServiceLigueHockeyV2.csproj ServiceLigueHockeyV2/
RUN dotnet restore ServiceLigueHockeyV2/ServiceLigueHockeyV2.csproj

# Copier tout le code source et compiler
COPY ServiceLigueHockeyV2/ ServiceLigueHockeyV2/
RUN dotnet build ServiceLigueHockeyV2/ServiceLigueHockeyV2.csproj -c Release -o /app/build

# Publier l'application
RUN dotnet publish ServiceLigueHockeyV2/ServiceLigueHockeyV2.csproj -c Release -o /app/publish

# Image finale - runtime seulement
FROM mcr.microsoft.com/dotnet/aspnet:10.0.7 AS final
WORKDIR /app

# Installer curl pour le healthcheck
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

# Copier l'application publiée
COPY --from=build /app/publish .

# Copier les fichiers de configuration
COPY ServiceLigueHockeyV2/appsettings.json ./appsettings.json
COPY ServiceLigueHockeyV2/appsettings.docker-dev.json ./appsettings.Development.json

# Exposer le port
EXPOSE 5298

# Variables d'environnement
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:5298

# Point d'entrée simple
ENTRYPOINT ["dotnet", "ServiceLigueHockeyV2.dll"]
