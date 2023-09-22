using Microsoft.EntityFrameworkCore;
using ShopTest.Data.Entities;

namespace ShopTest.Data
{
    public class ShopRepository : IShopRepository
    {
        private readonly ShopDbContext _context;

        public ShopRepository(ShopDbContext dbContext) 
        {
            _context = dbContext;   
        }  

        public async Task<List<Client>> GetCLientsByDirthDate(DateTime date)
        {
            return await _context.Clients
                .AsNoTracking()
                .Where(x => x.BirthDate.Date == date.Date)
                .ToListAsync();
        }

        public async Task<List<Client>> GetLastClients(int daysAgo)
        {
            throw new NotImplementedException();
        }
    }
}
