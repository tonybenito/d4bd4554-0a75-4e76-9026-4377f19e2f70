#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CodeTest.Api/CodeTest.Api.csproj", "CodeTest.Api/"]
COPY ["NumberSeries/NumberSeries.csproj", "NumberSeries/"]
RUN dotnet restore "CodeTest.Api/CodeTest.Api.csproj"
COPY . .
WORKDIR "/src/CodeTest.Api"
RUN dotnet build "CodeTest.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CodeTest.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CodeTest.Api.dll"]