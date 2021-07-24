# NuGet restore
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY *.sln .
COPY MyPersonalApi.Service/*.Service.csproj MyPersonalApi.Service/
COPY MyPersonalApi.BSL/*.csproj MyPersonalApi.BSL/
COPY MyPersonalApi.DAL/*.csproj MyPersonalApi.DAL/
RUN dotnet restore
COPY . .

# testing
FROM build AS testing
WORKDIR /src/MyPersonalApi.Service
RUN dotnet build

# publish
FROM build AS publish
WORKDIR /src/MyPersonalApi.Service
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
# ENTRYPOINT ["dotnet", "MyPersonalApi.Service.dll"]
# heroku uses the following
CMD ASPNETCORE_URLS=http://*:$PORT dotnet MyPersonalApi.Service.dll