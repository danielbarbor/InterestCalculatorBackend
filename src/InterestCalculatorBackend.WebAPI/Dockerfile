FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["InterestCalculatorBackend.WebAPI/InterestCalculatorBackend.WebAPI.csproj", "InterestCalculatorBackend.WebAPI/"]
COPY ["InterestCalculatorBackend.Abstractions/InterestCalculatorBackend.Abstractions.csproj", "InterestCalculatorBackend.Abstractions/"]
COPY ["InterestCalculatorBackend.Application/InterestCalculatorBackend.Application.csproj", "InterestCalculatorBackend.Application/"]
COPY ["InterestCalculatorBackend.InterestRateClient/InterestCalculatorBackend.InterestRateClient.csproj", "InterestCalculatorBackend.InterestRateClient/"]
RUN dotnet restore "InterestCalculatorBackend.WebAPI/InterestCalculatorBackend.WebAPI.csproj"
COPY . .
WORKDIR "/src/InterestCalculatorBackend.WebAPI"
RUN dotnet build "InterestCalculatorBackend.WebAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "InterestCalculatorBackend.WebAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "InterestCalculatorBackend.WebAPI.dll"]