#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Angular_.NET_SignalR_ChatApp/Angular_.NET_SignalR_ChatApp.csproj", "Angular_.NET_SignalR_ChatApp/"]
RUN dotnet restore "Angular_.NET_SignalR_ChatApp/Angular_.NET_SignalR_ChatApp.csproj"
COPY . .
WORKDIR "/src/Angular_.NET_SignalR_ChatApp"
RUN dotnet build "Angular_.NET_SignalR_ChatApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Angular_.NET_SignalR_ChatApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Angular_.NET_SignalR_ChatApp.dll"]