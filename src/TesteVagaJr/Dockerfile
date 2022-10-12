#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TesteVagaJr/TesteVagaJr.csproj", "src/TesteVagaJr/"]
RUN dotnet restore "src/TesteVagaJr/TesteVagaJr.csproj"
COPY . .
WORKDIR "/src/src/TesteVagaJr"
RUN dotnet build "TesteVagaJr.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TesteVagaJr.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TesteVagaJr.dll"]