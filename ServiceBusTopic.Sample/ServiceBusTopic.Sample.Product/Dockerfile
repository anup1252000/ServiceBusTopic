#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ServiceBusTopic.Sample.Product/ServiceBusTopic.Sample.Product.csproj ServiceBusTopic.Sample.Product/
RUN dotnet restore "ServiceBusTopic.Sample.Product/ServiceBusTopic.Sample.Product.csproj"
COPY . .
WORKDIR "/src/ServiceBusTopic.Sample.Product"
RUN dotnet build "ServiceBusTopic.Sample.Product.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServiceBusTopic.Sample.Product.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceBusTopic.Sample.Product.dll"]
