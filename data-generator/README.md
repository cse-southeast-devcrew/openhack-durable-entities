# Data Generator

This is a data generator to create and submit [on hand](docs/json/samples/input-onhand-sample.json) and [shipment](docs/json/samples/input-shipment-sample.json) documents to Cosmos DB.

## Prerequisites

1. Download and install [.NET Core](https://dotnet.microsoft.com/download)

2. Create a Cosmos DB account in Azure with a database containing two collections both partitioned on id. Recommended values in the table below.

|Database Name  |Collection Name  |Partition Key  |
|---------------|-----------------|---------------|
|inventory      |onHand           |/id            |
|inventory      |shipments        |/id            |

> Note: If you get 429 errors from Cosmos when writing to the `shipments` container it is because the `items` array is large and indexing that property drives up RU costs for writes. Add the json below to the excluded paths section of your shipment container's indexing policy to fix any 429 errors.
>
>```json
>{
>    "path": "/items/*"
>}
>```

3. Create a new  `appsettings.json` file in the root folder for the data generator to include your Cosmos DB account information

```json
{
  "CosmosEndpointUrl": "<URL to the Cosmos DB Endpoint>",
  "CosmosKey": "Read-Write Access Key",
  "CosmosDatabaseName": "inventory",
  "CosmosOnHandContainerName": "onHand",
  "CosmosShipmentContainerName": "shipments"
}
```

## Run the Application

The application will ask what type of data you want to generate then will create and insert the appropriate type(s) into Cosmos DB until you end the process.

To run enter `dotnet build` then `dotnet run` at the CLI.

When the generator runs, presents you with an menu. shown below:

``` bash

Welcome to the Inventory Data Generator

Please select one of the below by entering the corresponding number
     1. Generate On Hand data
     2. Generate Shipment data
     3. Generate both types
Please enter either 1, 2, or 3.

```

Selecting an option there, prompt the generator to start pumping test data into the Cosmos DB database specified in the `appsettings.json` file

The generator runs in an endless loop, unless the process is stopped. Stop the generator from the terminal window where it was launched from by pressing Ctrl+C.
