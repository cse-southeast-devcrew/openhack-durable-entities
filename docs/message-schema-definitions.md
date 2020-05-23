# Message Schema Definitions and Samples

## Cosmos DB Collections

### On Hand

This collection stores one document for each product in every store. It is partitioned by the `id` property, which is composed of `divId:storeId:upc`. A change feed listens to this collection and will get documents that have been changed or updated in batches. The schema of these incoming documents matches the schema of the original defined below.

Schema: [On Hand](./json/schemas/input-onHand-schema.json)

Example:

```json
{
  "id": "div1:store005:0003400029005",
  "divisionId": "div1",
  "storeId": "store005",
  "upc": "0003400029005",
  "inventoryCount": 1000,
  "productName": "HERSHEY'S Milk Chocolate Bars",
  "description": "HERSHEY'S Milk Chocolate Bars are the classic full size chocolate candy bars you’ve always enjoyed!",
  "lastUpdateTimestamp": "2020-05-13 9:00:00 AM"
}
```

Link: [On Hand Example](./json/samples/input-onHand-sample.json)

### Shipments

This collection stores one document for each shipment delivered to any store. It is partitioned by the `id` property, which is a GUID representing the shipment id. A change feed listens to this collection and will get documents that have been changed or updated in batches. The schema of these incoming documents matches the schema of the original defined below. The change feed processor will send one request to the Orchestrator for each item in the items array for the shipment.

Schema: [Shipment](./json/schemas/input-shipment-schema.json)

Example:

```json
{
  "id": "b501287e-e6e8-45e7-8dfe-d4107e96326a",
  "divisionId": "div1",
  "storeId": "store005",
  "distributorId": "vendor1",
  "items": [
    {
      "upc": "0303438929029",
      "shipmentAmount": 1000
    },
    {
      "upc": "1048400029901",
      "shipmentAmount": 1000
    },
    {
      "upc": "0003400029005",
      "shipmentAmount": 2000
    }
  ],
  "arrivalTimestamp": "2020-05-13 9:00:00 AM"
}
```

Link: [Shipment Example](./json/samples/input-shipment-sample.json)

### Master Data Collection (MDC)

This collection stores one document for each product in every store. It is partitioned by the `id` property, which is composed of `divId:storeId:upc`. This document is created or updated by the Orchestrator and its corresponding store entity.

Schema: [Master Data Container](./json/schemas/output-mds-schema.json)

Example:

```json
{
  "id": "div1:store005:0003400029005",
  "divisionId": "div1",
  "storeId": "store005",
  "upc": "0003400029005",
  "inventoryCount": 3000,
  "productName": "HERSHEY'S Milk Chocolate Bars",
  "description": "HERSHEY'S Milk Chocolate Bars are the classic full size chocolate candy bars you’ve always enjoyed!",
  "lastShipmentTimestamp": "2020-05-13 9:00:00 AM",
  "lastUpdateTimestamp": "2020-05-13 9:00:00 AM"
}
```

Link: [Master Data Container Document](./json/samples/output-mds-sample.json)
