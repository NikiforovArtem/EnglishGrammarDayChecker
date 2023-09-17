FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SqlLiteCreator/SqlLiteCreator.csproj", "SqlLiteCreator/"]
RUN dotnet restore "SqlLiteCreator/SqlLiteCreator.csproj"
COPY . .
WORKDIR "/src/SqlLiteCreator"
RUN dotnet build "SqlLiteCreator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SqlLiteCreator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SqlLiteCreator.dll"]
