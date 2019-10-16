FROM microsoft/dotnet:2.2-aspnetcore-runtime

LABEL version="1.0"

COPY dist /app

WORKDIR /app

EXPOSE 80/tcp

ENTRYPOINT ["dotnet", "WebApi.dll"]