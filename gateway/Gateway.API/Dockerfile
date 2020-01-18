FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
COPY  . /app
ENTRYPOINT ["dotnet", "Gateway.API.dll"]

#FROM microsoft/dotnet:2.2-sdk AS build
#WORKDIR /src
#COPY gateway/Gateway.API/Gateway.API.csproj gateway/Gateway.API/
#COPY gateway/Gateway.Common/Gateway.Common.csproj gateway/Gateway.Common/
#COPY core/Core.Common/Core.Common.csproj core/Core.Common/
#RUN dotnet restore gateway/Gateway.API/Gateway.API.csproj
#COPY . .
#WORKDIR /src/gateway/Gateway.API
#RUN dotnet build Gateway.API.csproj -c Release -o /app
#
#FROM build AS publish
#RUN dotnet publish Gateway.API.csproj -c Release -o /app
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "Gateway.API.dll"]
