# Base image with .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:7.0

# Install SQL Server client tools (optional)
RUN apt-get update && \
    apt-get install -y mssql-tools unixodbc-dev && \
    echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc && \
    apt-get clean && rm -rf /var/lib/apt/lists/*

# Set the working directory
WORKDIR /workspace
