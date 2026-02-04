FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy entire backend context so project references are available
COPY . ./

# Restore and publish the MyDoc project (references are relative to backend/)
RUN dotnet restore MyDoc/MyDoc.csproj
RUN dotnet publish MyDoc/MyDoc.csproj -c Release -o /app/out

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/out .

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 8080
ENTRYPOINT ["dotnet", "MyDoc.dll"]
