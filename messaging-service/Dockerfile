FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5294

ENV ASPNETCORE_URLS=http://+:5294

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["messaging-service/messaging-service.csproj", "messaging-service/"]
RUN dotnet restore "messaging-service/messaging-service.csproj"
COPY . .
WORKDIR "/src/messaging-service"
RUN dotnet build "messaging-service.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "messaging-service.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "messaging-service.dll"]
