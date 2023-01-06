#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MFAAuthApi/MFAAuthApi.csproj", "MFAAuthApi/"]
RUN dotnet restore "MFAAuthApi/MFAAuthApi.csproj"
COPY . .
WORKDIR "/src/MFAAuthApi"
RUN dotnet build "MFAAuthApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MFAAuthApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MFAAuthApi.dll"]