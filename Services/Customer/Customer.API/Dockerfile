#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Customer/Customer.API/Customer.API.csproj", "Services/Customer/Customer.API/"]
COPY ["Services/Customer/Customer.Infrastructure/Customer.Infrastructure.csproj", "Services/Customer/Customer.Infrastructure/"]
COPY ["Services/Customer/Customer.Domain/Customer.Domain.csproj", "Services/Customer/Customer.Domain/"]
COPY ["Services/Customer/Customer.Application/Customer.Application.csproj", "Services/Customer/Customer.Application/"]
COPY ["EventBus.Messages/EventBus.Messages.csproj", "EventBus.Messages/"]
RUN dotnet restore "Services/Customer/Customer.API/Customer.API.csproj"
COPY . .
WORKDIR "/src/Services/Customer/Customer.API"
RUN dotnet build "Customer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Customer.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customer.API.dll"]