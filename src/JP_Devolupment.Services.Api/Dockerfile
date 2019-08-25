FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["JP_Devolupment.Services.Api/JP_Devolupment.Services.Api.csproj", "JP_Devolupment.Services.Api/"]
RUN dotnet restore "Equinox.Services.Api/Equinox.Services.Api.csproj"
COPY . .
WORKDIR "/src/JP_Devolupment.Services.Api"
RUN dotnet build "JP_Devolupment.Services.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "JP_Devolupment.Services.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JP_Devolupment.Services.Api.dll"]