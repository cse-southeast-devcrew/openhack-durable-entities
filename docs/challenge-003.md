# Challenge 3: Add business logic to process the item messages

## Challenge Objective

For the last challenge, we want to write the aggregations from [Challenge 2](./challenge-002.md) into some "master data collection" (MDC). Again, we'll use a Cosmos DB collection as the MDC. After each store entity is finished aggregating the result, each item's aggregation should be written as either a new document in the MDC (for the first time we see that item) or as an update to an existing document.

Ultimately, this MDC will be used to quickly retrieve aggregations via some sort of API (which is beyond the scope of this challenge). The objective is to make sure the MDC is kept up-to-date with accurate inventory data.

## Brief Guidance

This challenge will focus on the red outlined area of the below design:

![Design](https://user-images.githubusercontent.com/1093738/82636141-ff2e9580-9bcf-11ea-9f84-38df789c088a.png)

To accomplish this challenge, you will use the `mdc` container that you created in [Challenge 1](./challenge-001.md) to store inventory data that the orchestrator receives after calling an entity to perform some aggregation.

## References

- [Azure Cosmos DB .NET Client](https://docs.microsoft.com/en-us/dotnet/api/overview/azure/cosmosdb?view=azure-dotnet)
- [Azure Activity Functions](https://docs.microsoft.com/en-us/azure/azure-functions/durable/durable-functions-types-features-overview#activity-functions)
- [Orchestrator function code constraints](https://docs.microsoft.com/en-us/azure/azure-functions/durable/durable-functions-code-constraints) (don't write directly to Cosmos DB from the orchestrator!)
- [Accessing environment variables](https://docs.microsoft.com/en-us/sandbox/functions-recipes/environment-variables?tabs=csharp#accessing-environment-variables) in Azure Functions

## Challenge Completion Criteria

To successfully complete the challenge:

- [ ] Ensure that sending a "shipment" or "onHand" event writes the updated inventory data for the item as a new row in the MDC
- [ ] Ensure that the inventory data written is accurate
- [ ] ⚠️ Do not write directly to Cosmos DB in the orchestrator!
