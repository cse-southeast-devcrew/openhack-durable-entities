# Challenge 1: Connect Azure Functions as Change Feed Listeners for Azure CosmosDB Containers

## Challenge Objective

**Congratulations!**

You have just completed setting up your development environment and ready to put together the first part of the solution.

As you read in the [solution design document](./solution-design.md), we process two key types of inventory data for a given store - On Hand and Shipments. These are stored in CosmosDB database on Azure, in different containers. As data arrives in these containers, we being processing data for aggregating inventory in the store.

The challenge objective is to invoke the processing, when the data arrives in the collection.

## Guidance

As part of this challenge we are focusing on the following red outlined area of the design.

![Focus for Challenge 1](./images/Challenge01Focus.png)

To accomplish this challenge, you will have to connect to your Azure Account and create a new Azure CosmosDB Account and database called - `inventory` using the **SQL API**.

In the CosmosDB database, create three containers:

- `shipments` (partition key: `/id`) : container for shipment documents.
- `onHand` (partition key: `/id`) : container for On Hand documents.
- `mdc` (partition key: `/id`): container representing the inventory for all stores and all items.

Find a way to observe the changes in the CosmosDB container and invoke the processing using Azure Functions. The Azure function should log the number of changed documents received and id of the first document.

## References

- [Azure Cosmos DB](https://azure.microsoft.com/en-us/free/cosmos-db/)
- [Creating collection in CosmosDB](https://docs.microsoft.com/en-us/azure/cosmos-db/how-to-create-container)
- [Azure CosmosDB - Change Feeds](https://docs.microsoft.com/en-us/azure/cosmos-db/change-feed)
- [Azure Functions](https://azure.microsoft.com/en-us/services/functions/)
- [Azure Functions Triggers and Bindings](https://docs.microsoft.com/en-us/azure/azure-functions/functions-triggers-bindings)
- [Azure Functions - CosmosDB Change Feed Trigger](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-cosmos-db-triggered-function)
- [C# Azure Functions - GitHub Samples](https://github.com/Azure-Samples/functions-docs-csharp)

### Terminology

- **Azure CosmosDB Change Feed**: A change feed in AzureDB CosmosDB is a list of documents that have been updated or inserted.

## Challenge Completion Criteria

To successfully, complete this challenge, we should have:

- [ ] Created a Azure CosmosDB database named - `inventory`.
- [ ] The Database should have three containers - `onHand`, `shipments` and `mdc`.
- [ ] There should a way to detect inserts and updates to the `onHand` and `shipments` containers.
- [ ] The processing of the events should show the number of changed documents and id of the first document for each collection.

## Next Steps

Now we have CosmosDB change feed rolling into Azure Functions, let's do something more **exciting** with the data in our next challenge.

Proceed to **[Challenge 2](challenge-002.md).**
