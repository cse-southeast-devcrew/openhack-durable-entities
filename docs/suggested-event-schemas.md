# Suggested Event Schemas

## Introduction

This document covers the suggested schemas for events and state for the durable entities. The participants are encouraged to explore options that they feel may be more appropriate for their solution.

## Event Schema

Each event represents changes to one product in a given store. The event schema coming from either the On Hand change feed processor or the Shipments change feed processor will be uniform, and a sample of each is represented in the event documents below.

Schema: [Event](./json/schemas/event-schema.json)

Example - **On Hand Event**:

```json
{
    "id": "div1:store005:0003400029005",
    "divisionId": "div1",
    "storeId": "store005",
    "upc": "0003400029005",
    "countAdjustment": 1000,
    "type": "onHandUpdate",
    "productName": "HERSHEY'S Milk Chocolate Bars",
    "description": "HERSHEY'S Milk Chocolate Bars are the classic full size chocolate candy bars you’ve always enjoyed!",
    "lastShipmentTimestamp": null,
    "lastUpdateTimestamp": "2020-05-13 9:00:00 AM"
}
```

Link: [On Hand Event](./json/samples/event-payload-sample-onHand.json)

Example - **Shipment**:

```json
{
    "id": "div1:store005:0003400029005",
    "divisionId": "div1",
    "storeId": "store005",
    "upc": "0003400029005",
    "countAdjustment": 3000,
    "type": "shipmentUpdate",
    "productName": null,
    "description": null,
    "lastShipmentTimestamp": "2020-05-13 9:00:00 AM",
    "lastUpdateTimestamp": "2020-05-13 9:00:00 AM"
}
```

Link: [Shipments Event](./json/samples/event-payload-sample-shipments.json)

## Entity Schema

Each entity represents the current state for a given store. It includes a dictionary of all products in the store (keyed by product `id`), each of which will be updated by incoming events and subsequently written to the Cosmos MDS collection.

Schema: [Entity](./json/schemas/entity-schema.json)

Example:

```json
{
    "storeId": "store005",
    "divisionId": "div1",
    "items":{
        "div1:store005:0003400029005": {
            "id": "div1:store005:0003400029005",
            "upc": "0003400029005",
            "inventoryCount": 3000,
            "productName": "HERSHEY'S Milk Chocolate Bars",
            "description": "HERSHEY'S Milk Chocolate Bars are the classic full size chocolate candy bars you’ve always enjoyed!",
            "lastShipmentTimestamp": "2020-05-13 2:00:00 AM",
            "lastUpdateTimestamp": "2020-05-13 9:00:00 AM"
        },
        "div1:store005:0003400029821": {
            "id": "div1:store005:0003400029821",
            "upc": "0003400029821",
            "inventoryCount": 1000,
            "productName": "Kit Kat Bars",
            "description": "Gimme a break, break me off a piece of that Kit Kat Bar!",
            "lastShipmentTimestamp": "2020-05-01 2:00:00 AM",
            "lastUpdateTimestamp": "2020-05-12 10:22:00 AM"
        }
    }
}

```

Link: [Entity](./json/samples/entity-sample.json)
