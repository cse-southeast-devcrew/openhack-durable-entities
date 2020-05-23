namespace InventoryManagement
{
    using System.Threading.Tasks;

    public interface ICounter
    {
        void Add(int amount);
        Task Reset();
        Task<int> Get();
        void Delete();
    }
}