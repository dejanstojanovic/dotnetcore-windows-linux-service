FROM microsoft/dotnet:2.1-sdk AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
#COPY . .
RUN git clone --single-branch -b single-library https://github.com/dejanstojanovic/dotnetcore-windows-linux-service.git
RUN cd dotnetcore-windows-linux-service
RUN dotnet publish "Sample.Service.csproj" --configuration=Release --runtime=linux-x64 --output=/app


FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Sample.Service.dll"]
