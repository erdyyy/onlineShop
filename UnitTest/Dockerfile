#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UnitTest/UnitTtest.csproj", "UnitTest/"]
COPY ["Services/Product/Product.API/Product.API.csproj", "Services/Product/Product.API/"]
COPY ["EventBus.Messages/EventBus.Messages.csproj", "EventBus.Messages/"]
COPY ["Services/Product/Product.Application/Product.Application.csproj", "Services/Product/Product.Application/"]
COPY ["Services/Product/Product.Domain/Product.Domain.csproj", "Services/Product/Product.Domain/"]
COPY ["Services/Product/Product.Infrastructure/Product.Infrastructure.csproj", "Services/Product/Product.Infrastructure/"]
RUN dotnet restore "UnitTest/UnitTtest.csproj"
COPY . .
WORKDIR "/src/UnitTest"
RUN dotnet build "UnitTtest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UnitTtest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UnitTtest.dll"]