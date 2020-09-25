FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY published/Carrefour.WebApp.dll ./
ENTRYPOINT ["dotnet", "Carrefour.WebApp.dll"]