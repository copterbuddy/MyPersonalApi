FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS runtime
    WORKDIR /app
    COPY . .
    CMD ASPNETCORE_URLS=http://*:$PORT dotnet MyPersonalApi.Service.dll