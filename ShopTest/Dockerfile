#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ShopTest/ShopTest.csproj", "ShopTest/"]
RUN dotnet restore "ShopTest/ShopTest.csproj"
COPY . .
WORKDIR "/src/ShopTest"
RUN dotnet build "ShopTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopTest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopTest.dll"]