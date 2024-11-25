FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Kopier prosjektfilen
COPY ["/Karverket.csproj", "./"]

# Gjenopprett avhengigheter
RUN dotnet restore "./Karverket.csproj"

# Kopier resten av prosjektet
COPY . .

# Installer Node.js og Tailwind CSS
RUN apt-get update && apt-get install -y curl && \
    curl -fsSL https://deb.nodesource.com/setup_18.x | bash - && \
    apt-get install -y nodejs && \
    npm install -g npm@latest && \
    npm install

# Bygg prosjektet
RUN dotnet build "./Karverket.csproj" -c Release -o /app/build

# Publiser prosjektet
RUN dotnet publish "./Karverket.csproj" -c Release -o /app/publish /p:UseAppHost=false


FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Karverket.dll"]
