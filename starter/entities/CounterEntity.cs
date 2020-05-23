using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;

namespace InventoryManagement
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Counter : ICounter
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [FunctionName(nameof(Counter))]
        public static Task counter([EntityTrigger] IDurableEntityContext ctx)
            => ctx.DispatchAsync<Counter>();

        public void Add(int amount)
        {
            this.Value += amount;
        }

        public Task Reset()
        {
            this.Value = 0;
            return Task.CompletedTask;
        }

        public Task<int> Get()
        {
            return Task.FromResult(this.Value);
        }

        public void Delete()
        {
            Entity.Current.DeleteState();
        }


    }

}