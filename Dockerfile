FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HIVBackend.csproj", "."]
RUN dotnet restore "./HIVBackend.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "HIVBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HIVBackend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://*:5000
ENTRYPOINT ["dotnet", "HIVBackend.dll", "--server.urls"]
EXPOSE 5000