# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os arquivos de projeto e restaura dependências
COPY ["Ambev.Tech.DeveloperStore.WebApi/Ambev.Tech.DeveloperStore.WebApi.csproj", "Ambev.Tech.DeveloperStore.WebApi/"]
COPY ["Ambev.Tech.DeveloperStore.Application/Ambev.Tech.DeveloperStore.Application.csproj", "Ambev.Tech.DeveloperStore.Application/"]
COPY ["Ambev.Tech.DeveloperStore.Domain/Ambev.Tech.DeveloperStore.Domain.csproj", "Ambev.Tech.DeveloperStore.Domain/"]
COPY ["Ambev.Tech.DeveloperStore.Infrastructure/Ambev.Tech.DeveloperStore.Infrastructure.csproj", "Ambev.Tech.DeveloperStore.Infrastructure/"]

RUN dotnet restore "Ambev.Tech.DeveloperStore.WebApi/Ambev.Tech.DeveloperStore.WebApi.csproj"

# Copia todo o código
COPY . .

# Publica a aplicação
WORKDIR "/src/Ambev.Tech.DeveloperStore.WebApi"
RUN dotnet publish -c Release -o /app/publish --no-restore

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copia os arquivos da build
COPY --from=build /app/publish .

# Expor a porta padrão da aplicação
EXPOSE 80
EXPOSE 443

# Habilita variáveis de ambiente customizadas se necessário
ENV ASPNETCORE_URLS=http://+:80
ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

# ENTRYPOINT padrão para executar a aplicação
ENTRYPOINT ["dotnet", "Ambev.Tech.DeveloperStore.WebApi.dll"]
