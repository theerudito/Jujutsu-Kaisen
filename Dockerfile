FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copiar los archivos de la solución y restaurar las dependencias
COPY ./*.sln ./
COPY ./JujutsuKaisen.Backend/*.csproj ./JujutsuKaisen.Backend/
COPY ./JujutsuKaisen.Frontend/*.csproj ./JujutsuKaisen.Frontend/
COPY ./JujutsuKaisen.Database/*.csproj ./JujutsuKaisen.Database/
COPY ./JujutsuKaisen.Helpers/*.csproj ./JujutsuKaisen.Helpers/
COPY ./JujutsuKaisen.Models/*.csproj ./JujutsuKaisen.Models/
COPY ./JujutsuKaisen.Repository/*.csproj ./JujutsuKaisen.Repository/


# Restaurar las dependencias
RUN dotnet restore

# Copiar todo el código fuente y compilar la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa de tiempo de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 80

# Define el comando de inicio para ejecutar la aplicación
ENTRYPOINT ["dotnet", "JujutsuKaisen.Backend.dll", "JujutsuKaisen.Frontend.dll"] 