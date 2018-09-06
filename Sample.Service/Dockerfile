FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
RUN git clone --single-branch -b single-library https://github.com/dejanstojanovic/dotnetcore-windows-linux-service.git
RUN cd dotnetcore-windows-linux-service
RUN dotnet publish "./dotnetcore-windows-linux-service/Sample.Service/Sample.Service.csproj" --configuration=Release --runtime=linux-x64 --output=/app

FROM microsoft/dotnet:2.1-sdk AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "Sample.Service.dll"]
