FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["StudentAdminPortal.API/StudentAdminPortal.API.csproj", "StudentAdminPortal.API/"]
RUN dotnet restore "StudentAdminPortal.API/StudentAdminPortal.API.csproj"
COPY . .
WORKDIR "/src/StudentAdminPortal.API"
RUN dotnet build "StudentAdminPortal.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudentAdminPortal.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentAdminPortal.API.dll"]
