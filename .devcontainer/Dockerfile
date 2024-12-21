# Use Ubuntu as the base image
FROM ubuntu:22.04

# Install dependencies and .NET SDK
RUN apt-get update && apt-get install -y wget curl git && \
    wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    apt-get update && apt-get install -y dotnet-sdk-8.0 && \
    apt-get clean && rm -rf /var/lib/apt/lists/*

# Set working directory
WORKDIR /workspace
