using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace InventoryManagement
{
    public static class InventoryOrchestrator_HttpStart
    {
        [FunctionName("InventoryOrchestrator_HttpStart")]
        public static async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestMessage req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            string data = await req.Content.ReadAsStringAsync().ConfigureAwait(false);

            // Function input comes from the request content.
            string instanceId = await starter.StartNewAsync<string>("CounterOrchestration", null, data).ConfigureAwait(false);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}