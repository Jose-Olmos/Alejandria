#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5001
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Alejandria.WebAPI/Alejandria.WebAPI.csproj", "Alejandria.WebAPI/"]
COPY ["Alejandria.WebAPI.Implementation/Alejandria.WebAPI.Implementation.csproj", "Alejandria.WebAPI.Implementation/"]
COPY ["Alejandria.NotificationService.Contract/Alejandria.NotificationService.Contract.csproj", "Alejandria.NotificationService.Contract/"]
RUN dotnet restore "Alejandria.WebAPI/Alejandria.WebAPI.csproj"
COPY . .
WORKDIR "/src/Alejandria.WebAPI"
RUN dotnet build "Alejandria.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Alejandria.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY ["Alejandria.WebAPI/Certificates/*", "Certificates/"]
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Alejandria.WebAPI.dll"]