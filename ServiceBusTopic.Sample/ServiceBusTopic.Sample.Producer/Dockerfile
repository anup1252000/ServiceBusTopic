#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ServiceBusTopic.Sample.Producer/ServiceBusTopic.Sample.Producer.csproj ServiceBusTopic.Sample.Producer/
COPY ServiceBusTopic.Sample.Common/ServiceBusTopic.Sample.Common.csproj ServiceBusTopic.Sample.Common/
RUN dotnet restore "ServiceBusTopic.Sample.Producer/ServiceBusTopic.Sample.Producer.csproj"
COPY . .
WORKDIR "/src/ServiceBusTopic.Sample.Producer"
RUN dotnet build "ServiceBusTopic.Sample.Producer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServiceBusTopic.Sample.Producer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceBusTopic.Sample.Producer.dll"]
