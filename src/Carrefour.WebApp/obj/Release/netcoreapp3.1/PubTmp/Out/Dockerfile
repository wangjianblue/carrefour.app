FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5000
COPY . .
#COPY published/Carrefour.WebApp.dll ./
ENTRYPOINT ["dotnet", "Carrefour.WebApp.dll"]