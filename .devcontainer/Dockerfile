FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim

# Install SQL Server client tools
RUN apt-get update && apt-get install -y mssql-tools unixodbc-dev && \
    echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc && \
    apt-get clean && rm -rf /var/lib/apt/lists/*

# Set the working directory
WORKDIR /workspace
