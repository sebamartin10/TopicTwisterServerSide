#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["APITopicTwister/APITopicTwister.csproj", "APITopicTwister/"]
COPY ["Repository/Repository.csproj", "Repository/"]
COPY ["Services/Services.csproj", "Services/"]
COPY ["Models/Models.csproj", "Models/"]
RUN dotnet restore "APITopicTwister/APITopicTwister.csproj"
COPY . .
WORKDIR "/src/APITopicTwister"
RUN dotnet build "APITopicTwister.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APITopicTwister.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APITopicTwister.dll"]