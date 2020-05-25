using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace InventoryDataGenerator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddUserSecrets<Program>();

            IConfigurationRoot config = builder.Build();

            // Validate config values are present
            if (string.IsNullOrEmpty(config["CosmosEndpointUrl"]))
            {
                throw new ArgumentNullException("Please enter the Cosmos endpoint url in appsettings.json");
            }
            if (string.IsNullOrEmpty(config["CosmosKey"]))
            {
                throw new ArgumentNullException("Please enter the Cosmos key in appsettings.json");
            }

            var generator = new EventGenerator(config);

            await Run(generator);

            return;
        }

        private static async Task Run(EventGenerator generator)
        {
            Console.WriteLine(@"Welcome to the Inventory Data Generator

Please select one of the below by entering the corresponding number
     1. Generate On Hand data
     2. Generate Shipment data
     3. Generate both types");

            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || !(input == 1 || input == 2 || input == 3))
            {
                Console.WriteLine("Please enter either 1, 2, or 3.");
            };

            switch (input)
            {
                case 1:
                    await generator.InsertOnHand();
                    break;
                case 2:
                    await generator.InsertShipments();
                    break;
                case 3:
                    await generator.InsertBoth();
                    break;
            }
        }
    }
}
