#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["110-ContainerMVC.csproj", "."]
RUN dotnet restore "./110-ContainerMVC.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "110-ContainerMVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "110-ContainerMVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "110-ContainerMVC.dll"]