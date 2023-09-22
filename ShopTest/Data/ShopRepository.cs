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
            var clients = await _context.Clients
                .AsNoTracking()
                .Where(x => x.Purchases
                .Any(y => y.Date >= DateTime.UtcNow
                .AddDays(-daysAgo)))
                .ToListAsync();
            return clients;
        }
        
        public async Task<List<Client>> GetClientIdWithEagerLoading(long clientId)
        {
            var clients = await _context.Clients                
                .AsNoTracking()
                .Where(x => x.Id == clientId)
                .Include(x => x.Purchases)
                .ThenInclude(x => x.Products)
                .ThenInclude(x => x.Category)
                .ToListAsync();

            return clients;
        }

        public async Task<List<Product>> GetProductsByClientId(long clientId)
        {
            var products = await _context.Clients
                .AsNoTracking()
                .Where(x => x.Id == clientId)
                .SelectMany(x => x.Purchases)
                .SelectMany(x => x.Products)
                .Distinct().ToListAsync();

            return products;
        }

        public async Task<Dictionary<string, int>> GetCategoriesFrequencyByClientId(long clientId)
        {
            var categoriesFrequencies = await _context.Clients
                .AsNoTracking()
                .SelectMany(x => x.Purchases)
                .SelectMany(x => x.Products)
                .Select(x => x.Category)
                .GroupBy(x => x.Name)
                .ToDictionaryAsync(x => x.Key, x => x.Count());

            return categoriesFrequencies;
        }       
    }
}
