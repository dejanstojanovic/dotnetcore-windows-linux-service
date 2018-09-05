FROM microsoft/dotnet:2.1-sdk AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR ./
COPY . .
RUN dotnet publish --configuration=Release --runtime=linux-x64 --output=./build
COPY . .
WORKDIR /build


FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Sample.Service"]
