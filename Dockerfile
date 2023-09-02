FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HIVBackend.csproj", "."]
RUN dotnet restore "./HIVBackend.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "HIVBackend.csproj" -c Release -o /app/build

# —обираем приложение дл€ публикации
FROM build AS publish
RUN dotnet publish "HIVBackend.csproj" -c Release -o /app/publish

#  опируем приложение в базовый образ
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HIVBackend.dll"]