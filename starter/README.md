# Durable Functions - Starter Code

## Introduction

This sample code demonstrates the features of Azure Functions - Durable Entities and how they can be used to maintain state in a Serverless Environment. It is also the foundational code that you can use to complete the challenges as part of the OpenHack.

The code has been set up to work with Visual Studio code in a Dev Container hosted on Docker running on the workstation.

The Docker container is built from the Docker configuration file -  `DockerFile` in the `.devcontainer/` folder, when VS Code opens this project in an container. Initial setup can take up to 10-15 minutes when the container is built but subsequent starts should take less than a minute.

The starter code also contains VS Code settings configured to debugging of Azure Functions code.

## Pre-requisites

### System Requirements

To run this code, you will need:

- A workstation with 64-bit processor with Second Level Address Translation (SLAT) or Mac hardware - 2010 model or later
- BIOS-level hardware virtualization support enabled in the BIOS settings (for Workstation running Windows 10)
- Operating systems: Windows 10 (64-bit) Pro/Enterprise/Education (Build 15063 or later)or MacOS (10.13 or newer)
- 8 GB of RAM
- Keyboard and Mouse

### Software

The following software should be installed on the workstation, prior to running this code:

- [Docker Desktop for Windows or Mac](https://docs.docker.com/desktop/)
- [Visual Studio Code](https://code.visualstudio.com/)
- [Remote Development Extension Pack for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.vscode-remote-extensionpack)

The docker container that will be built on your workstation, as part of this code will contain additional software required to support development of this application. For the full list of software and Visual Code extensions installed on the container, see the Appendix section below.

### Azure Subscription

To run this code, you will also require an active Azure Subscription.

### Stable Internet connection

To run this code, you will also require a stable Internet connection, which allows interaction with Azure and DockerHub, while building the Docker container and running the code in the container.

## Getting Started

We will get started using the following steps:

- [Step 1: Build the Docker based Development Environment using Visual Studio Code](./docs/vscode-remote-development.md)
- [Step 2: Create an Azure Storage Account for the Azure Functions backend](./docs/azurefunctions-storage-setup.md)
- [Step 3: Run the sample code from command line and debug the code](./docs/azurefunctions-running-debugging.md)

## Appendix: Software included in the Dev Container

- Microsoft .NET Core SDK Version 3.1 (Base Docker Image)
- Azure CLI
- Azure Functions Core Tools v3
- Terraform version 0.12.25
- TF Lint version 0.13.2
- GraphViz
- Visual Studio Code Extensions:
  - Azure Account
  - Azure CLI Tools
  - Azure Functions
  - Azure Pipelines
  - C#
  - Docker
  - REST Client
  - VS Code Live Share Extension Pack
  - Terraform
- Visual Studio Code Server (software that interacts with VS Code IDE)
