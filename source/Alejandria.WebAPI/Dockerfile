FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

EXPOSE 5000 5001

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY Alejandria.WebAPI/*.csproj ./Alejandria.WebAPI/
COPY Alejandria.WebAPI.Implementation/*.csproj ./Alejandria.WebAPI.Implementation/

RUN dotnet restore

# Copy everything else and build
COPY Alejandria.WebAPI/. ./Alejandria.WebAPI/
COPY Alejandria.WebAPI.Implementation/. ./Alejandria.WebAPI.Implementation/

# Build runtime image
WORKDIR /app/Alejandria.WebAPI
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 
WORKDIR /app
COPY --from=build-env /app/Alejandria.WebAPI/out .
ENTRYPOINT ["dotnet", "Alejandria.WebAPI.dll"]