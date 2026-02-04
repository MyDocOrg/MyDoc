# 1. Imagen base para build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# 2. Copiamos csproj y restauramos dependencias
COPY *.csproj .
RUN dotnet restore

# 3. Copiamos todo y compilamos
COPY . .
RUN dotnet publish -c Release -o out

# 4. Imagen final (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 8080
ENTRYPOINT ["dotnet", "AuthService.dll"]
