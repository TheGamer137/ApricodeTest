FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApricodeTest/ApricodeTest.csproj", "ApricodeTest/"]
RUN dotnet restore "ApricodeTest/ApricodeTest.csproj"
COPY . .
WORKDIR "/src/ApricodeTest"
RUN dotnet build "ApricodeTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApricodeTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApricodeTest.dll"]
