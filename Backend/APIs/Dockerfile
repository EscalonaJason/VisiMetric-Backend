FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["APIs/APIs.csproj", "APIs/"]
RUN dotnet restore "APIs/APIs.csproj"
COPY . .
WORKDIR "/src/APIs"
RUN dotnet build "APIs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APIs.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIs.dll"]
