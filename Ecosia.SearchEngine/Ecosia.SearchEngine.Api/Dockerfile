FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ecosia.SearchEngine.Api/Ecosia.SearchEngine.Api.csproj", "Ecosia.SearchEngine.Api/"]
RUN dotnet restore "Ecosia.SearchEngine.Api/Ecosia.SearchEngine.Api.csproj"
COPY . .
WORKDIR "/src/Ecosia.SearchEngine.Api"
RUN dotnet build "Ecosia.SearchEngine.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ecosia.SearchEngine.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecosia.SearchEngine.Api.dll"]
