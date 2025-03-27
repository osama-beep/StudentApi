FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["StudentApi.csproj", "./"]
RUN dotnet restore "StudentApi.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "StudentApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudentApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentApi.dll"]
