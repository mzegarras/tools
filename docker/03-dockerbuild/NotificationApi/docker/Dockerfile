#FROM mcr.microsoft.com/dotnet/core/runtime:2.2
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app


COPY ./bin/Release/netcoreapp2.2/publish/ /app

ENV ASPNETCORE_URLS=http://+:8080
ENV APP_NET_BROKER_URI="activemq:tcp://activemq1:61616"

EXPOSE 8080

ENTRYPOINT ["dotnet", "/app/NotificationApi.dll"]