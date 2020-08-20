FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY . .

FROM build AS publish
RUN dotnet publish "SeminarskiRS2.webApi" -c Release -o /app
FROM base AS final
WORKDIR /app
COPY --from=publish /app . 

ENTRYPOINT ["dotnet","SeminarskiRS2.webApi.dll"]