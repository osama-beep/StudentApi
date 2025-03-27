# Usa l'immagine SDK per il build dell'app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["StudentApi.csproj", "./"]
RUN dotnet restore "StudentApi.csproj"
COPY . . 
WORKDIR "/src/"
RUN dotnet build "StudentApi.csproj" -c Release -o /app/build

# Pubblica l'app
FROM build AS publish
RUN dotnet publish "StudentApi.csproj" -c Release -o /app/publish

# Usa l'immagine per l'esecuzione .NET (ASP.NET runtime)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentApi.dll"]
