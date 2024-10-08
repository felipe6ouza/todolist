FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Todolist.WebAPI/Todolist.WebAPI.csproj", "src/Todolist.WebAPI/"]
COPY ["src/Todolist.Application/Todolist.Application.csproj", "src/Todolist.Application/"]
COPY ["src/Todolist.Domain/Todolist.Domain.csproj", "src/Todolist.Domain/"]
COPY ["src/Todolist.Infrastructure/Todolist.Infrastructure.csproj", "src/Todolist.Infrastructure/"]
RUN dotnet restore "./src/Todolist.WebAPI/./Todolist.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/Todolist.WebAPI"
RUN dotnet build "./Todolist.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Todolist.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Todolist.WebAPI.dll"]