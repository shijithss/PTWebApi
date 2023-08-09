#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PTWebAPI/User.Microservice.csproj", "PTWebAPI/"]
RUN dotnet restore "PTWebAPI/User.Microservice.csproj"
COPY . .
WORKDIR "/src/PTWebAPI"
RUN dotnet build "User.Microservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "User.Microservice.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:7253 DOTNET_RUNNING_IN_CONTAINER=true 
ENTRYPOINT ["dotnet", "User.Microservice.dll"]
