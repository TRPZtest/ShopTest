using ShopTest.Data.Entities;

namespace ShopTest.Data
{
    public interface IShopRepository
    {
        public Task<List<Client>> GetCLientsByDirthDate(DateTime date);
        public Task<List<Client>> GetLastClients(int daysAgo);              
    }
}
