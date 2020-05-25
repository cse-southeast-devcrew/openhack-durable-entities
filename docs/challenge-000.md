# Challenge 0: Preparing the kitchen

## Challenge Objective

The goal for this challenge is to set up and verify your development environment. This includes setting up and verifying a Docker container for remote development using Visual Studio Code, creating Azure Cosmos DB database and collection and populating the collections with test data.

## Guidance

### Install Prerequisites

Ensure you have a Microsoft Windows 10 or MacOS powered workstation with the following installed:

- [ ] [Docker Desktop for Windows/MacOS](https://www.docker.com/products/docker-desktop)
- [ ] [Visual Studio Code](https://code.visualstudio.com/)
- [ ] [Visual Studio Code - Remote Development Extension Pack](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.vscode-remote-extensionpack)
- [ ] [Azure Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer/)

### Docker Setup

We'll be using a [dev container](https://code.visualstudio.com/docs/remote/containers) for this OpenHack to seamlessly set up your environment. To get started, follow these steps:

For Windows / macOS:

1. Open Docker Desktop.
2. Right-click on the Docker task bar item, select **Settings / Preferences** and update **Resources > File Sharing** with any locations your source code is kept. See [tips and tricks](https://code.visualstudio.com/docs/remote/troubleshooting#_container-tips) for troubleshooting.

### Getting started with the Dev Container

Follow the instructions provided in the [Starter](../starter) folder to get started with Docker container based remote development.

### Create Azure Cosmos DB account, database and collections

Using Azure Cosmos DB documentation referenced below, create:

- Azure DB Account using the **SQL API** (Prefix the account name with the team number. For example - Team 1 - `cosmos-kimopenhack001`)
- Cosmos DB Data - `inventory`
- Following containers with partition keys

    | Container Name | Partition Key | Description               |
    | -------------- | ------------  |---------------------------
    | onHand         | /id           | container for On Hand documents |
    | shipments      | /id           | container for shipment documents |
    | mds            | /id           | master data store (MDS) container representing the inventory for all stores and all items. |

### Run the data generator to insert on hand and shipment records

Follow the instructions on [Data Generator](../data-generator) folder to configure and insert dummy records into the onHand and shipment containers.

## References

- [VS Code Developing inside a Container](https://code.visualstudio.com/docs/remote/containers)
- [Azure Cosmos DB](https://azure.microsoft.com/en-us/free/cosmos-db/)
- [Creating collection in Cosmos DB](https://docs.microsoft.com/en-us/azure/cosmos-db/how-to-create-container)

## Challenge Completion Criteria

- [ ] All of the necessary prerequisites are installed.
- [ ] Your project is open in a dev container in VS Code.
- [ ] The starter code builds and runs successfully.
- [ ] The starter code can be debugged successfully with hitting the two breakpoints in entity and orchestration.
- [ ] Azure Cosmos DB account configured with the database and containers.
- [ ] Data was populated into the onHand and shipment collections using data generator.

## Next Steps

Now that you have your dev environment setup and the starter code running in a Dev container using VS Code. Azure Cosmos DB has been set up and data is showing up in the collections. It's time to begin processing data from Cosmos DB.

Proceed to [Challenge 1](challenge-001.md).
