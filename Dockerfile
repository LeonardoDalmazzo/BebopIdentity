# Estágio 1: Build
# CORRIGIDO: Alterado de 8.0 para 9.0 para corresponder ao seu .csproj
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia o .csproj e restaura as dependências
COPY identityAuthentication/identityAuthentication.csproj identityAuthentication/
RUN dotnet restore identityAuthentication/identityAuthentication.csproj

# Copia o resto dos arquivos do projeto e publica
COPY . .
WORKDIR "/src/identityAuthentication"
RUN dotnet publish "identityAuthentication.csproj" -c Release -o /app/publish

# Estágio 2: Runtime
# CORRIGIDO: Alterado de 8.0 para 9.0
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expõe a porta que o Blazor Server usa
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Comando de entrada para rodar o app
ENTRYPOINT ["dotnet", "identityAuthentication.dll"]