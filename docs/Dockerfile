#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Carrefour.WebApp/Carrefour.WebApp.csproj", "src/Carrefour.WebApp/"]
COPY ["src/Carrefour.Web.Framework/Carrefour.Web.Framework.csproj", "src/Carrefour.Web.Framework/"]
COPY ["src/Carrefour.Services/Carrefour.Services.csproj", "src/Carrefour.Services/"]
COPY ["src/Carrefour.Data/Carrefour.Data.csproj", "src/Carrefour.Data/"]
COPY ["src/Carrefour.Core/Carrefour.Core.csproj", "src/Carrefour.Core/"]
RUN dotnet restore "src/Carrefour.WebApp/Carrefour.WebApp.csproj"
COPY . .
WORKDIR "/src/src/Carrefour.WebApp"
RUN dotnet build "Carrefour.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Carrefour.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Carrefour.WebApp.dll"]