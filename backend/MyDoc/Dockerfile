FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiamos los csproj primero (caching óptimo)
COPY MyDoc/MyDoc.csproj MyDoc/
COPY MyDoc.Application/MyDoc.Application.csproj MyDoc.Application/
COPY MyDoc.Infrastructure/MyDoc.Infrastructure.csproj MyDoc.Infrastructure/

RUN dotnet restore MyDoc/MyDoc.csproj

# Copiamos todo el código
COPY . .

RUN dotnet publish MyDoc/MyDoc.csproj -c Release -o /app/publish

# ---------- RUNTIME ----------
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "MyDoc.dll"]