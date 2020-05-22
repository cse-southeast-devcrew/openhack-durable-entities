# Challenge 2: Invoke a durable entity per store to receive item related messages

## Challenge Objective
In Challenge 1 you deployed the master data store in Cosmos DB and hooked up the change feed processors with Azure Functions.

In this challenge, we'll use the change feed processors to communicate with Durable Entities representing each store.

data coming in from cosmos needs to be sent as an event
pass the data to the durable entities

## Guidance

During this challenge, we'll be working on this section of the architecture
However, feel free to explore designs that differ from the suggested architecture flow.
INSERT IMAGE 

- Items will be added to the Cosmos DB inventory database in two ways: onhand updates and shipments, each represented by a change feed listener Azure function.

    - Onhand updates: Representing an adjusted inventory count, say for example, due to an inventory assessment in a store.
    - Shipments: Represented by a list of items added to inventory with UPCs and amounts.

- The data will be simulated by a Data Generator that sends json items to Cosmos in the format of the provided schemas (ADD LINK).

- The incoming data coming in will need to be mapped to outgoing event schemas in order to be sent to the durable function. 

- The documents will be processed by the entities to finally update the Master Data Store in Challenge 3.

## References

- Docs on azure functions 
- docs on durable entities 
- Signal Entities: webhooks for durable entities

## Challenge Completion Criteria

- [ ] Data coming into Cosmos from generator is being sent from change feed to durable entity(ies)