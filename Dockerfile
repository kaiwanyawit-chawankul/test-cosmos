FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app
COPY . .

RUN dotnet restore

WORKDIR /app
RUN dotnet build
