FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["JP_Devolupment.UI.Web/JP_Devolupment.UI.Web.csproj", "JP_Devolupment.UI.Web/"]
RUN dotnet restore "JP_Devolupment.UI.Web/JP_Devolupment.UI.Web.csproj"
COPY . .
WORKDIR "/src/JP_Devolupment.UI.Web"
RUN dotnet build "JP_Devolupment.UI.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "JP_Devolupment.UI.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JP_Devolupment.UI.Web.dll"]