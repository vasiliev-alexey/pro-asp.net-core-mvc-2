FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["PartyInvates/PartyInvates.csproj", "PartyInvates/"]
RUN dotnet restore "PartyInvates/PartyInvates.csproj"
COPY . .
WORKDIR "/src/PartyInvates"
RUN dotnet build "PartyInvates.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PartyInvates.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PartyInvates.dll"]