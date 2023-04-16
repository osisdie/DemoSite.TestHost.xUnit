FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /build
COPY . .

# --------------------------
# Build & Publish
# --------------------------
RUN dotnet restore "src/DemoSite/DemoSite.csproj" 
RUN dotnet publish "src/DemoSite/DemoSite.csproj" -c Release -o /app --no-restore

FROM base AS final
WORKDIR /app
COPY --from=build /app .

ENTRYPOINT ["dotnet", "DemoSite.dll"]

