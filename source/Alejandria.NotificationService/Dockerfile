#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 4001
EXPOSE 4000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Alejandria.NotificationService/Alejandria.NotificationService.csproj", "Alejandria.NotificationService/"]
COPY ["Alejandria.NotificationService.Implementation/Alejandria.NotificationService.Implementation.csproj", "Alejandria.NotificationService.Implementation/"]
COPY ["Alejandria.NotificationService.Contract/Alejandria.NotificationService.Contract.csproj", "Alejandria.NotificationService.Contract/"]
RUN dotnet restore "Alejandria.NotificationService/Alejandria.NotificationService.csproj"
COPY . .
WORKDIR "/src/Alejandria.NotificationService"
RUN dotnet build "Alejandria.NotificationService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Alejandria.NotificationService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY ["Alejandria.NotificationService/Certificates/*", "Certificates/"]
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Alejandria.NotificationService.dll"]