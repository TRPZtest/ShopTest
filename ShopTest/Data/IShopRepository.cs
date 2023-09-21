using ShopTest.Data.Entities;

namespace ShopTest.Data
{
    public interface IShopRepository
    {
        public Task<List<Client>> GetCLientsByDirthDate(DateTime date);
    }
}
