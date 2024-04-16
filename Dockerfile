FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
ENV TZ=Europe/Moscow
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

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
RUN mkdir -p /app/wwwroot/Files
ENV ASPNETCORE_URLS=http://*:5000
ENTRYPOINT ["dotnet", "HIVBackend.dll", "--server.urls"]
EXPOSE 5000