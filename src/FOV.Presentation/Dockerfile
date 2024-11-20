#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER root
RUN apt-get update && apt-get install -y libgdiplus \
    && ln -sf /usr/lib/libgdiplus.so /usr/lib/libgdiplus.so.0 \
    && rm -rf /var/lib/apt/lists/*
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/FOV.Presentation/FOV.Presentation.csproj", "FOV.Presentation/"]
COPY ["src/FOV.Application/FOV.Application.csproj", "FOV.Application/"]
COPY ["src/FOV.Infrastructure/FOV.Infrastructure.csproj", "FOV.Infrastructure/"]
COPY ["src/FOV.Domain/FOV.Domain.csproj", "FOV.Domain/"]
RUN dotnet restore "./FOV.Presentation/FOV.Presentation.csproj"
COPY src/ .
WORKDIR "/src/FOV.Presentation"
RUN dotnet build "./FOV.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FOV.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FOV.Presentation.dll"]
