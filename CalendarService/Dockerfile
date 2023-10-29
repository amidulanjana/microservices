FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY CalendarService.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0
ARG DbConnection=""
ENV DB_CONNECTION=$DbConnection
ARG ServiceBusConnection=""
ENV SERVICE_BUS_CONNECTION=$ServiceBusConnection
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "CalendarService.dll"]