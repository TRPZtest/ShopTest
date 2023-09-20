using Microsoft.EntityFrameworkCore;

namespace ShopTest.Data
{
    public class ShopDbContext : DbContext
    {



        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }
    }
}
