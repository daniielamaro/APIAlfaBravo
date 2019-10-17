FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base

LABEL version ="1.0" maintainer="AlfaBravo"

WORKDIR /app

COPY ./deploy/ .

ENTRYPOINT ["dotnet", "WebApi.dll"]