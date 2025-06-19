FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app

COPY . .
#RUN dotnet restore

#RUN dotnet publish -o out
#RUN dotnet publish "EiosCore.Presentation/EiosCore.Presentation.csproj" -c Release -o /publish
RUN dotnet restore
RUN dotnet publish -c Release -o out

WORKDIR /app/out

EXPOSE 5065
ENTRYPOINT ["dotnet", "ToDoList.API.dll"]