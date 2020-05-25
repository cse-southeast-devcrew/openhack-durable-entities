using System;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using InventoryDataGenerator.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace InventoryDataGenerator
{
    public class EventGenerator
    {
        private static string _database;
        private static string _onHandContainer;
        private static string _shipmentsContainer;
        private static CosmosClient _client;

        // Every run with the same seed value will produce the same set of divisionIds, storeIds, and upcs
        // If you desire a new set of random values change the seed
        // For more information see https://github.com/bchavez/Bogus#using-local-seed-determinism
        private const int _seedValue = 1234;

        private const int _numDivisions = 10;
        private const int _numStores = 50;
        private const int _numUpcs = 10000;
        
        private readonly string[] _divisionIds;
        private readonly string[] _storeIds;
        private readonly string[] _upcs;

        public EventGenerator(IConfiguration config)
        {
            // Setup Cosmos
            _database = config["CosmosDatabaseName"];
            _onHandContainer = config["CosmosOnHandContainerName"];
            _shipmentsContainer = config["CosmosShipmentContainerName"];

            _client = new CosmosClient(config["CosmosEndpointUrl"], config["CosmosKey"]);

            // Set up common inventory data
            var faker = new Faker("en")
            {
                Random = new Randomizer(_seedValue)
            };

            // Array of 10 divisions
            _divisionIds = Enumerable.Range(1, _numDivisions)
                .Select(_ => faker.Random.AlphaNumeric(4))
                .ToArray();
            // Array of 50 stores
            _storeIds = Enumerable.Range(1, _numStores)
                .Select(_ => faker.Random.AlphaNumeric(6))
                .ToArray();
            // Array of 10,000 upcs
            _upcs = Enumerable.Range(1, _numUpcs)
                .Select(_ => faker.Random.Int(10000000, 99999999).ToString())
                .ToArray();
        }

        public async Task InsertOnHand()
        {
            int i = 0;
            int errors = 0;
            while(true)
            {
                var onHand = GenerateOnHand();

                if(await AddItem(onHand, _onHandContainer)) // Inserted document successfully
                {
                    i++;
                }
                else
                {
                    errors++;
                }

                if (i % 10 == 0)
                {
                    Console.WriteLine($"Added onHand document {i}. {errors} errors.");
                }
            }
        }

        public async Task InsertShipments()
        {
            int i = 0;
            int errors = 0;
            while (true)
            {
                var shipments = GenerateShipments();

                if (await AddItem(shipments, _shipmentsContainer)) // Inserted document successfully
                {
                    i++;
                }
                else
                {
                    errors++;
                }

                if (i % 10 == 0)
                {
                    Console.WriteLine($"Added shipments document {i}. {errors} errors.");
                }
            }
        }

        public async Task InsertBoth()
        {
            int o = 0;
            int s = 0;
            int oErrors = 0;
            int sErrors = 0;
            while (true)
            {
                var onHand = GenerateOnHand();
                var shipments = GenerateShipments();

                if (await AddItem(onHand, _onHandContainer)) // Inserted on hand document successfully
                {
                    o++;
                }
                else
                {
                    oErrors++;
                }

                if (await AddItem(shipments, _shipmentsContainer)) // Inserted shipments document successfully
                {
                    s++;
                }
                else
                {
                    sErrors++;
                }

                if (o % 10 == 0)
                {
                    Console.Write($"Added onhand document {o}. {oErrors} errors.    ");
                    Console.WriteLine($"Added shipment document {s}. {sErrors} errors.");
                }
            }
        }

        private static async Task<bool> AddItem(dynamic item, string containerName)
        {
            var db = _client.GetDatabase(_database);
            var container = db.GetContainer(containerName);

            try
            {
                await container.UpsertItemAsync(item, new PartitionKey(item.id));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return false;
            }

            return true;
        }

        private OnHand GenerateOnHand()
        {
            var onHandFaker = new Faker<OnHand>()
                .RuleFor(i => i.divisionId, f => f.PickRandom(_divisionIds))
                .RuleFor(i => i.storeId, f => f.PickRandom(_storeIds))
                .RuleFor(i => i.upc, f => f.PickRandom(_upcs))
                .RuleFor(i => i.id, (f, i) => $"{i.divisionId}:{i.storeId}:{i.upc}")
                .RuleFor(i => i.inventoryCount, f => f.Random.Int(100, 5000))
                .RuleFor(i => i.productName, f => f.Commerce.ProductName())
                .RuleFor(i => i.description, f => f.Lorem.Sentence(10, 15))
                .RuleFor(i => i.lastUpdateTimestamp, f => DateTime.UtcNow);

            return onHandFaker.Generate();
        }

        private Shipment GenerateShipments()
        {
            var shipmentItemFaker = new Faker<ShipmentItem>()
                .RuleFor(i => i.upc, f => f.PickRandom(_upcs))
                .RuleFor(i => i.shipmentAmount, f => f.Random.Int(100, 5000));

            var shipmentFaker = new Faker<Shipment>()
                .RuleFor(i => i.id, f => Guid.NewGuid().ToString())
                .RuleFor(i => i.divisionId, f => f.PickRandom(_divisionIds))
                .RuleFor(i => i.storeId, f => f.PickRandom(_storeIds))
                .RuleFor(i => i.distributorId, f => f.Random.AlphaNumeric(10))
                .RuleFor(i => i.items, f => shipmentItemFaker.Generate(f.Random.Int(10, 500)).ToArray())
                .RuleFor(i => i.arrivalTimestamp, f => DateTime.UtcNow);

            return shipmentFaker.Generate();
        }
    }
}
