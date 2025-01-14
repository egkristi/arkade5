# Use the official .NET SDK image as the build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the solution file and all project files first
COPY ["Arkivverket.Arkade.sln", "./"]
COPY ["Arkivverket.Arkade.API/Arkivverket.Arkade.API.csproj", "Arkivverket.Arkade.API/"]
COPY ["Arkivverket.Arkade.Core/Arkivverket.Arkade.Core.csproj", "Arkivverket.Arkade.Core/"]
COPY ["Arkivverket.Arkade.Core.Tests/Arkivverket.Arkade.Core.Tests.csproj", "Arkivverket.Arkade.Core.Tests/"]
COPY ["Arkivverket.Arkade.CLI/Arkivverket.Arkade.CLI.csproj", "Arkivverket.Arkade.CLI/"]
COPY ["Arkivverket.Arkade.CLI.Tests/Arkivverket.Arkade.CLI.Tests.csproj", "Arkivverket.Arkade.CLI.Tests/"]
COPY ["Arkivverket.Arkade.GUI/Arkivverket.Arkade.GUI.csproj", "Arkivverket.Arkade.GUI/"]
COPY ["Arkivverket.Arkade.GUI.Installer/Arkivverket.Arkade.GUI.Installer.wixproj", "Arkivverket.Arkade.GUI.Installer/"]

# Restore NuGet packages
RUN dotnet restore

# Copy the rest of the source code
COPY . .

# Build and publish the API project
RUN dotnet publish "Arkivverket.Arkade.API/Arkivverket.Arkade.API.csproj" -c Release -o /app/publish

# Use the official ASP.NET runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

# Create directory for temporary files
RUN mkdir -p /app/temp && \
    chown -R 1001:1001 /app/temp

# Switch to non-root user for security
USER 1001

# Copy the published application
COPY --from=build /app/publish .

# Set environment variables
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production
ENV TempDirectory=/app/temp

# Expose the API port
EXPOSE 8080

ENTRYPOINT ["dotnet", "Arkivverket.Arkade.API.dll"]
